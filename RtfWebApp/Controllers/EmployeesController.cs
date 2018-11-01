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
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ApiBaseController<Employee>
    {
        
        public EmployeesController(ApplicationDbContext context):
            base(context)
        {
        }
         
    }
}