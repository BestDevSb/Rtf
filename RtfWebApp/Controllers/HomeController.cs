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
                SkilGroups = CreateSkilGroups(id)
            };

            return View(result);
        }

        private SkilGroup[] CreateSkilGroups(int employeeId)
        {
            return Enumerable.Range(0, employeeId).Select(CreateSkilGroup).ToArray();
        }

        private SkilGroup CreateSkilGroup(int id)
        {
            return new SkilGroup
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
