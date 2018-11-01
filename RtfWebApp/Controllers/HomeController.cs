using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RtfWebApp.Models;
using RtfWebApp.Models.View;

namespace RtfWebApp.Controllers
{
    public class HomeController : Controller
    {
        private static Random _rnd = new Random();

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Users()
        {
            List<UserViewModel> result = new List<UserViewModel>();
            for (int i = 0; i < 10; i++)
            {
                result.Add(new UserViewModel
                {
                    Id = i,
                    Name = "Test user name " + i,
                    AvatarId = i
                });
            }
            return View(result);
        }

        public IActionResult Projects()
        {
            return View();
        }

        public IActionResult User(int id)
        {
            UserViewModel result = new UserViewModel
            {
                Age = 23 + _rnd.Next(40),
                Name = "Adam Yanukovich " + _rnd.Next(11),
                Sex = "M",
                FeedBackQuality = _rnd.Next(100),
                AvatarId = id,
                Id = id,
                SkilGroups = CreateSkilGroups(3)
            };

            return View(result);
        }

        private SkilGroup[] CreateSkilGroups(int count)
        {
            return Enumerable.Range(0, count).Select(CreateSkilGroup).ToArray();
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
