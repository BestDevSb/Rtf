using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RtfWebApp.Data;
using RtfWebApp.Models;
using RtfWebApp.Models.View;

namespace RtfWebApp.Controllers
{
    public class HomeController : Controller
    {
        private ApplicationDbContext _context = null;

        public HomeController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static Random _rnd = new Random();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            List<UserViewModel> result = _context.Employees.Select(u =>
                new UserViewModel
                {
                    Id = u.Id,
                    Name = u.Name,
                    AvatarId = Math.Abs(u.Name.GetHashCode()) % 9
                }
                ).ToList();

            return View(result);
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult User(int id)
        {
            var emp = _context.Employees.FirstOrDefault(ee => ee.Id == id);

            UserViewModel result = new UserViewModel
            {
                Age = 23 + _rnd.Next(40),
                Name = emp.Name,
                Sex = "M",
                FeedBackQuality = _rnd.Next(100),
                AvatarId = id % 9,
                Id = id,
                SkilGroups = CreateSkillGroups(id)
            };

            return View(result);
        }

        private SkillGroup[] CreateSkillGroups(int employeeId)
        {
            var ratings = _context.Ratings.Where(r => r.EmployeeId == employeeId).ToList();
            var skillsId = ratings.Select(r => r.SkillId).ToArray();
            var skills = _context.Skills.Where(s => skillsId.Contains(s.Id)).ToList();

            return skills.GroupBy(s => s.Category).Select( c => new SkillGroup
            {
                Name = c.Key.ToString(),
                Skils = CreateSkills(ratings, c.ToList())
            }).ToArray();
        }

        private SkilInfo[] CreateSkills(List<Rating> ratings, List<Skill> skills)
        {
            return skills.Select(s => new SkilInfo
            {
                Name = s.Name,
                Rate = CalcSkillRate(ratings, s)
            }).ToArray();
        }

        private double CalcSkillRate(List<Rating> ratings, Skill skill)
        {
            var validRatings = ratings.Where(r => r.SkillId == skill.Id).ToList();

            double ratingSum = validRatings.Sum(r => r.Rate * r.Weight);
            double weightSum = validRatings.Sum(r => r.Weight);

            return ratingSum / weightSum;
        }

        private SkillGroup CreateSkilGroup(int id)
        {
            return new SkillGroup
            {
                Name = "Skil group " + id,
                Skils = Enumerable.Range(0, 2 + _rnd.Next(5)).Select(CreateSkil).ToArray()
            };
        }

        private SkilInfo CreateSkil(int id)
        {
            return new SkilInfo
            {
                Name = "Skil info " + id,
                Rate = _rnd.Next(11)
            };
        }

        public IActionResult Reports()
        {
            return View();
        }
        public IActionResult SendFeedback()
        {
            return View();
        }

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
