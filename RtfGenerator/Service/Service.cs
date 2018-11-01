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
        private const string _csSkillApi = "/api/skill";
        private const string _csProfileApi = "/api/profile";
        private const string _csProfileSkillsApi = "/api/profileskills";
        private const string _csRateApi = "/api/rate";
        private const string _csSolutionsApi = "/api/solutions";
        private const string _csSolutionsSkillsApi = "/api/solutionsskills";

        private static Func<string, string> _cleanApi = api => $"{api}/clean";
        private static Func<string, string> _rangeApi = api => $"{api}/range";

        private readonly IRestClient _client;
        private readonly IRandomIndexGenerator _generator;

        internal Service(string baseUrl, IRandomIndexGenerator generator)
        {
            _generator = generator ?? throw new ArgumentNullException(nameof(generator));

            _client = new RestClient(baseUrl);
        }

        private async Task ExecuteDeleteAsync(string resource)
        {
            var request = new RestRequest(resource, Method.DELETE) { RequestFormat = DataFormat.Json };

            await _client.ExecuteTaskAsync(request);
        }

        private async Task ExecutePostAsync<T>(string resource, T value)
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

        private Task CreateEmployeesAsync(IEnumerable<Employee> employees) => ExecutePostAsync($"{_csEmployeeApi}/range", employees);
        private async Task<List<Employee>> GetEmployeesAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csEmployeeApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Employee[]>(response.Content).ToList();
        }

        private Task CreateProfilesAsync(IEnumerable<Profile> profiles) => ExecutePostAsync($"{_csProfileApi}/range", profiles);
        private async Task<List<Profile>> GetProfilesAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csProfileApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<Profile[]>(response.Content).ToList();
        }

        private Task CreateSkillsAsync(IEnumerable<Skill> skills) => ExecutePostAsync($"{_csSkillApi}/range", skills);
        private async Task<List<Skill>> GetSkillsAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csSkillApi);

            return response.StatusCode == System.Net.HttpStatusCode.NotFound
                ? new List<Skill>()
                : Newtonsoft.Json.JsonConvert.DeserializeObject<Skill[]>(response.Content).ToList();
        }

        private Task CreateSolutionsAsync(IEnumerable<Solution> solutions) => ExecutePostAsync($"{_csSolutionsApi}/range", solutions);
        private async Task<List<Solution>> GetSolutionsAsync()
        {
            return Newtonsoft.Json.JsonConvert.DeserializeObject<Solution[]>((await ExecuteGetListAsync(_csSolutionsApi)).Content).ToList();
        }

        private Task CreateRatingsAsync(IEnumerable<Rating> ratings) => ExecutePostAsync($"{_csRateApi}/ratings", ratings);

        private Task CreateProfileSkillsAsync(IEnumerable<ProfileSkills> profileSkills) => ExecutePostAsync($"{_csProfileSkillsApi}/range", profileSkills);
        private async Task<List<ProfileSkills>> GetProfileSkillsAsync()
        {
            IRestResponse response = await ExecuteGetListAsync(_csProfileSkillsApi);

            return Newtonsoft.Json.JsonConvert.DeserializeObject<ProfileSkills[]>(response.Content).ToList();
        }

        private async Task GenerateSkillsAsync()
        {
            var presentSkills = (await GetSkillsAsync()).GroupBy(i => i.Category).ToDictionary(k => k.First().Category, v => new HashSet<string>(v.Select(i => i.Name)));

            var skillsDict = new Dictionary<SkillCategory, HashSet<string>>
            {
                [SkillCategory.Hard] = new HashSet<string> { "C++", "C#", "Python", "Java", "F#", "R", "Go", "JavaScript", "Scala" },
                [SkillCategory.Soft] = new HashSet<string> { "Эмоциональный интеллект", "Самооценка", "Адаптивность", "Конфликтология", "Клиентоцентричность" }
            };

            List<Skill> newSkills = new List<Skill>();

            foreach(SkillCategory category in skillsDict.Keys)
            {
                if (!presentSkills.ContainsKey(category))
                    presentSkills[category] = new HashSet<string>();
                foreach(string skillName in skillsDict[category].Except(presentSkills[category]))
                {
                    newSkills.Add(new Skill
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
            await ExecuteDeleteAsync(_cleanApi(_csProfileSkillsApi));
            await ExecuteDeleteAsync(_cleanApi(_csProfileApi));

            var presentedProfiles = (await GetProfilesAsync()).Select(i => i.Name).ToHashSet();
            var profiles = Enumerable.Range(0, 30).Select(i => $"Профиль {i}").ToHashSet();

            var workItems = profiles.Except(presentedProfiles);
            if (!(workItems?.Any() ?? false))
                return;

            var newProfiles = workItems.Select(n => new Profile { Name = n }).ToList();
            await CreateProfilesAsync(newProfiles);

            var skills = (await GetSkillsAsync()).ToList();

            IGenerator<Skill> skillGenerator = new Generator<Skill>(_generator);
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
                        SkillId = skillId
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

        public async Task GenerateHRRatingsAsync()
        {
            await ExecuteDeleteAsync($"{_csRateApi}/clean");

            var employeesTask = GetEmployeesAsync();
            var profilesTask = GetProfilesAsync();
            var skillsTask = GetSkillsAsync();

            var employees = (await employeesTask).ToDictionary(k => k.Id);
            var profiles = (await profilesTask).ToDictionary(k => k.Id);
            var skills = (await skillsTask).ToDictionary(k => k.Id);
            var profileSkills = (await GetProfileSkillsAsync()).GroupBy(p => p.ProfileId).ToDictionary(k => k.First().ProfileId, v => v.ToList());

            var ratings = new List<Rating>();
            foreach(Employee employee in employees.Values)
            {
                var profile = profiles[employee.ProfileId];

                foreach(var skill in profileSkills[profile.Id])
                {
                    var rating = new Rating
                    {
                        EmployeeId = employee.Id,
                        Rate = _generator.GetNext(1, 10),
                        SkillId = skill.SkillId,
                    };

                    ratings.Add(rating);
                }
            }

            await CreateRatingsAsync(ratings);
        }

        public async Task GenerateSolutionsAsync()
        {
            await ExecuteDeleteAsync(_cleanApi(_csSolutionsSkillsApi));
            await ExecuteDeleteAsync(_cleanApi(_csSolutionsApi));


            var skillsTask = GetSkillsAsync();
            var solutions = Enumerable.Range(0, 20).Select(s => new Solution { Title = $"Решение {s}" });
            await CreateSolutionsAsync(solutions);

            var solutionSkills = new List<SolutionSkils>();
            var skills = await skillsTask;
            IGenerator<Skill> skillGenerator = new Generator<Skill>(_generator);

            foreach(Solution solution in await GetSolutionsAsync())
            {
                for(int index = 0; index < _generator.GetNext(0, 5); index++)
                {
                    var solSkill = new SolutionSkils
                    {
                        SolutionId = solution.Id,
                        SkillId = skillGenerator.GetNext(skills).Id
                    };

                    solutionSkills.Add(solSkill);
                }
            }

            await ExecutePostAsync(_rangeApi(_csSolutionsSkillsApi), solutionSkills);
        }
    }
}
