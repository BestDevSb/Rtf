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
        private const string _csEmployeeApi = "/api/employees";
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

        private Task CreateEmployeeAsync(Employee employee) => ExecutePost(_csEmployeeApi, employee);
        private async Task<List<Employee>> GetEmployeesAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csEmployeeApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Employee[]>(response.Content).ToList();
        }

        private Task CreateProfileAsync(Profile profile) => ExecutePost(_csProfileApi, profile);
        private async Task<List<Profile>> GetProfilesAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csProfileApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Profile[]>(response.Content).ToList();
        }

        private Task CreateSkillAsync(Skill skill) => ExecutePost(_csSkillApi, skill);
        private async Task<List<Skill>> GetSkillsAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csSkillApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Skill[]>(response.Content).ToList();
        }

        private Task CreateProfileSkill(ProfileSkills profileSkill) => ExecutePost(_csProfileSkillsApi, profileSkill);

        private async Task GenerateSkillsAsync()
        {
            var presentSkills = (await GetSkillsAsync()).GroupBy(i => i.Category).ToDictionary(k => k.First().Category, v => new HashSet<string>(v.Select(i => i.Name)));

            var skillsDict = new Dictionary<SkillCategory, HashSet<string>>
            {
                [SkillCategory.Hard] = new HashSet<string> { "C++", "C#", "Python", "Java", "F#", "R", "Go", "JavaScript", "Scala" },
                [SkillCategory.Soft] = new HashSet<string> { "Эмоциональный интеллект", "Самооценка", "Адаптивность", "Конфликтология", "Клиентоцентричность" }
            };

            foreach(SkillCategory category in skillsDict.Keys)
            {
                if (!presentSkills.ContainsKey(category))
                    presentSkills[category] = new HashSet<string>();
                foreach(string skillName in skillsDict[category].Except(presentSkills[category]))
                {
                    await CreateSkillAsync(new Skill
                    {
                        Name = skillName,
                        Category = category
                    });
                }
            }
        }

        private async Task GenerateProfilesAsync()
        {
            var presentedProfiles = (await GetProfilesAsync()).Select(i => i.Name).ToHashSet();
            var profiles = Enumerable.Range(0, 30).Select(i => $"Профиль {i}").ToHashSet();

            var workItems = profiles.Except(presentedProfiles);
            if (workItems?.Any() ?? false)
            {
                foreach (var profileName in workItems)
                {
                    await CreateProfileAsync(new Profile
                    {
                        Name = profileName
                    });
                }
            }

            var skills = (await GetSkillsAsync()).ToList();

            IGenerator<Skill> skillGenerator = new Generator<Skill>(_generator);
            IGenerator<Profile> profileGenerator = new Generator<Profile>(_generator);
            HashSet<int> profileSkills = new HashSet<int>();

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

                    await CreateProfileSkill(new ProfileSkills
                    {
                        ProfileId = profile.Id,
                        SkilId = skillId
                    });
                }

                profileSkills.Clear();
            }
        }

        private async Task GenerateEmployeesAsync()
        {
            await Task.Delay(0);
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
