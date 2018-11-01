using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace RtfWebApp.Controllers
{
    using Models;
    using Data;
    using RtfWebApp.Models;
    using RtfWebApp.Controllers.Models.Api;

    public class SolutionController : ApiBaseController<Solution>
    {
        public SolutionController(ApplicationDbContext context) : base(context)
        {
        }

        [HttpGet("api/[controller]/Vote/{solutionId}/{employeeId}/{vote}")]
        public SolutionResolution Vote(int solutionId, int employeeId, Vote vote)
        {
            return SolutionResolution.Unset;
        }

        [HttpGet("api/[controller]/FindEmployees/{solutionId}/{employeeId}/{vote}")]
        public IEnumerable<Employee> FindEmployees(int solutionId)
        {
            return new[] { new Employee { Id = -1, Name = "Test" }  };
        }

        [HttpGet("api/[controller]/getsolutionrecomendedemployees/{solutionId}")]
        public IEnumerable<SolutionRecomendedEmployees> GetRecomendedEmployees(int solutionId)
        {
            return _context.SolutionRecomendedEmployees.Where(x => x.SolutionId == solutionId).OrderBy(x => x.RateSum);
        }
    }
}
