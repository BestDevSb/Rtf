using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RtfGenerator.Generator;
using RtfWebApp.Models;

namespace RtfGenerator.Service
{
    internal class Service : IService
    {
        private const string _csEmployeeApi = "/api/employees/";
        private const string _csSkillApi = "/api/skil";
        private const string _csProfileApi = "/api/profile";
        private const string _csProfileSkillsApi = "/api/profileskills";

        private readonly IRestClient _client;
        private readonly IRandomIndexGenerator _generator;

        internal Service(string baseUrl, IRandomIndexGenerator generator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));

            _client = new RestClient(baseUrl);
        }

        private async Task ExecutePost<T>(string resource, T value)
        {
            var request = new RestRequest(resource, Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(value);

            await _client.ExecutePostTaskAsync(request);
        }

        private async Task<IRestResponse> ExecuteGetListAsync(string resource)
        {
            var request = new RestRequest(resource, Method.GET) { RequestFormat = DataFormat.Json };

            return await _client.ExecuteGetTaskAsync(request);
        }

        private Task CreateEmployeesAsync(IEnumerable<Employee> employees) => ExecutePost($"{_csEmployeeApi}/range", employees);
        private async Task<List<Employee>> GetEmployeesAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csEmployeeApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Employee[]>(response.Content).ToList();
        }

        private Task CreateProfilesAsync(IEnumerable<Profile> profiles) => ExecutePost($"{_csProfileApi}/range", profiles);
        private async Task<List<Profile>> GetProfilesAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csProfileApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Profile[]>(response.Content).ToList();
        }

        private Task CreateSkillsAsync(IEnumerable<Skil> skills) => ExecutePost($"{_csSkillApi}/range", skills);
        private async Task<List<Skil>> GetSkillsAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csSkillApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Skil[]>(response.Content).ToList();
        }

        private Task CreateProfileSkillsAsync(IEnumerable<ProfileSkills> profileSkills) => ExecutePost($"{_csProfileSkillsApi}/range", profileSkills);

        private async Task GenerateSkillsAsync()
        {
            var presentSkills = (await GetSkillsAsync()).GroupBy(i => i.Category).ToDictionary(k => k.First().Category, v => new HashSet<string>(v.Select(i => i.Name)));

            var skillsDict = new Dictionary<SkillCategory, HashSet<string>>
            {
                [SkillCategory.Hard] = new HashSet<string> { "C++", "C#", "Python", "Java", "F#", "R", "Go", "JavaScript", "Scala" },
                [SkillCategory.Soft] = new HashSet<string> { "Эмоциональный интеллект", "Самооценка", "Адаптивность", "Конфликтология", "Клиентоцентричность" }
            };

            List<Skil> newSkills = new List<Skil>();

            foreach(SkillCategory category in skillsDict.Keys)
            {
                if (!presentSkills.ContainsKey(category))
                    presentSkills[category] = new HashSet<string>();
                foreach(string skillName in skillsDict[category].Except(presentSkills[category]))
                {
                    newSkills.Add(new Skil
                    {
                        Name = skillName,
                        Category = category
                    });
                }
            }

            await CreateSkillsAsync(newSkills);
        }

        private async Task GenerateProfilesAsync()
        {
            var presentedProfiles = (await GetProfilesAsync()).Select(i => i.Name).ToHashSet();
            var profiles = Enumerable.Range(0, 30).Select(i => $"Профиль {i}").ToHashSet();

            var workItems = profiles.Except(presentedProfiles);
            if (!(workItems?.Any() ?? false))
                return;

            var newProfiles = workItems.Select(n => new Profile { Name = n }).ToList();
            await CreateProfilesAsync(newProfiles);

            var skills = (await GetSkillsAsync()).ToList();

            IGenerator<Skil> skillGenerator = new Generator<Skil>(_generator);
            IGenerator<Profile> profileGenerator = new Generator<Profile>(_generator);
            HashSet<int> profileSkills = new HashSet<int>();

            var newProfileSkills = new List<ProfileSkills>();

            foreach (Profile profile in await GetProfilesAsync())
            {
                int skillsNumber = _generator.GetNext(1, skills.Count);
                for(int skillIndex = 0; skillIndex < skillsNumber; skillIndex++)
                {
                    int skillId = -1;
                    do
                    {
                        skillId = skillGenerator.GetNext(skills).Id;
                    } while (profileSkills.Contains(skillId));

                    profileSkills.Add(skillId);


                    newProfileSkills.Add(new ProfileSkills
                    {
                        ProfileId = profile.Id,
                        SkilId = skillId
                    });
                }

                profileSkills.Clear();
            }

            await CreateProfileSkillsAsync(newProfileSkills);
        }

        private async Task GenerateEmployeesAsync()
        {
            var existenceEmployees = (await GetEmployeesAsync()).Select(i => i.Name).ToHashSet();
            var employees = Enumerable.Range(0, 100).Select(i => $"Сотрудник {i + 1}").ToHashSet();

            var workItems = employees.Except(existenceEmployees);

            if (!(workItems?.Any() ?? false))
                return;

            var profiles = await GetProfilesAsync();
            IGenerator<Profile> profileGenerator = new Generator<Profile>(_generator);

            await CreateEmployeesAsync(workItems.Select(name =>
            {
                return new Employee
                {
                    Name = name,
                    ProfileId = profiles[_generator.GetNext(0, profiles.Count)].Id
                };
            }));
        }

        public async Task GenerateAsync()
        {
            Task skillsTask = GenerateSkillsAsync();
            Task profileTask = skillsTask.ContinueWith(t => GenerateProfilesAsync()).Unwrap();
            Task employeeTask = profileTask.ContinueWith(t => GenerateEmployeesAsync()).Unwrap();

            await employeeTask;
        }
    }
}
