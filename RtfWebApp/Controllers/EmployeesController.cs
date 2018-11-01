using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RtfWebApp.Controllers
{
    using Models;
    using Data;
    using RtfWebApp.Models;
    using RtfWebApp.Controllers.Models.Api;

    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ApiBaseController<Employee>
    {
        
        public EmployeesController(ApplicationDbContext context):
            base(context)
        {
        }

        [HttpGet("api/[controller]/FindSameProfiles/{employeeId}")]
        public IEnumerable<ProfileInfo> FindSameProfiles(int employeeId)
        {
            throw new NotImplementedException();
        }
    }
}