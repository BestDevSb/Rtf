using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RestSharp;
using RtfWebApp.Models;

namespace RtfGenerator.Service
{
    internal class Service : IService
    {
        private readonly IRestClient _client;

        internal Service(string baseUrl)
        {
            _client = new RestClient(baseUrl);
        }

        private async Task CreateEmployeeAsync(Employee employee)
        {
            var request = new RestRequest("/api/Employees", Method.POST);
            request.AddBody(employee);

            await _client.ExecutePostTaskAsync(request);
        }
        private async Task CreateSkillAsync(Skil skill)
        {
            var request = new RestRequest("/api/skil", Method.POST) { RequestFormat = DataFormat.Json };
            request.AddBody(skill);

            await _client.ExecutePostTaskAsync(request);
        }

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
                    await CreateSkillAsync(new Skil
                    {
                        Name = skillName,
                        Category = category
                    });
                }
            }
        }

        private IEnumerable<Employee> MakeEmployees()
        {
            yield break;
        }

        public async Task<IEnumerable<Employee>> GetEmployeesAsync()
        {
            var request = new RestRequest("api/employees", Method.GET) { RequestFormat = DataFormat.Json };

            return await _client.GetAsync<List<Employee>>(request);
        }

        public async Task<IEnumerable<Skil>> GetSkillsAsync()
        {
            var request = new RestRequest("/api/skil", Method.GET);

            return await _client.GetAsync<List<Skil>>(request);
        }

        public async Task GenerateAsync()
        {
            Task skillsTask = GenerateSkillsAsync();


            await skillsTask;

            foreach(Employee employee in MakeEmployees())
            {
                await CreateEmployeeAsync(employee);
            }
        }
    }
}
