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
    public class SolutionController : Controller
    {
        private ApplicationDbContext _context = null;

        public SolutionController(ApplicationDbContext context)
        {
            _context = context;
        }

        private static Random _rnd = new Random();

        public IActionResult Index()
        {
            List<SolutionViewModel> result = _context.Solution.Select(u =>
                new SolutionViewModel
                {
                    Id = u.Id,
                    Name = u.Title
                }
                ).ToList();

            return View(result);
        }
        
        public IActionResult Item(int id)
        {
            var emp = _context.Employees.FirstOrDefault(ee => ee.Id == id);

            UserViewModel result = new UserViewModel
            {
                Age = 23 + _rnd.Next(40),
                Name = emp.Name,
                Sex = "M",
                FeedBackQuality = _rnd.Next(100),
                AvatarId = id % 9,
                Id = id
            };

            return View(result);
        }
    }
}
