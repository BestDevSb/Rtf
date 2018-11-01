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
            List<SolutionViewModel> result = _context.Solutions.Select(u =>
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
            var solution = _context.Solutions.FirstOrDefault(ee => ee.Id == id);
            var solSkills = _context.SolutionsSkills.Where(s => s.SolutionId == id);
            var skillsId = solSkills.Select(s => s.SkillId).ToList();

            var skills = _context.Skills.Where(s => skillsId.Contains(s.Id)).ToArray();
            var solEmp = _context.EmployeeSolutions.Where(ee => ee.SolutionId == id);
            var solEmpId = solEmp.Select(s => s.EmployeeId).ToList();

            var employees = _context.Employees.Where(em => solEmpId.Contains(em.Id)).ToArray();

            SolutionViewModel result = new SolutionViewModel
            {
                Name = solution.Title,
                Employees = employees,
                Id = id,
                Resolution = Models.Api.SolutionResolution.Unset,
                Skills = skills.Select(s => new SkilInfo
                {
                    Name = s.Name
                }).ToArray()
            };

            return View(result);
        }

        public ActionResult FindEmployees(int id)
        {
            var reqEmp = _context.SolutionRecomendedEmployees.Where(emp => emp.SolutionId == id).ToList();
            var empIds = reqEmp.Select(s => s.EmployeeId).ToList();
            var employees = _context.Employees.Where(em => empIds.Contains(em.Id))
                .Select(HomeController.ToUserViewModel).ToList();

            return View("~/Views/Home/Users.cshtml", employees);
        }
    }
}
