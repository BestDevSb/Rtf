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

    [Route("api/[controller]/")]
    [ApiController]
    public class EmployeesController : ApiBaseController<Employee>
    {
        
        public EmployeesController(ApplicationDbContext context):
            base(context)
        {
        }

        /// <summary>
        /// Оценка деятельности сотрудника за период
        /// 0 - 10
        /// 0 - нет данных
        /// 1- 6 негатив
        /// 7 - 8 - норм
        /// 9 - 10 - позитив
        /// </summary>
        /// <param name="employeeId"></param>
        /// <param name="from"></param>
        /// <param name="to"></param>
        /// <returns></returns>
        [HttpGet("api/[controller]/calcrating/")]
        public int CalcRating(int employeeId, DateTime from, DateTime to)
        {
            return 0;
        }

        [HttpGet("api/[controller]/getrating/{employeeId}")]
        public IEnumerable<EmployeeRating> GetRating(int employeeId)
        {
            return _context.EmployeeRating.Where(employee => employee.EmployeeId == employeeId);
        }

        [HttpGet("api/[controller]/getrating")]
        public IEnumerable<EmployeeRating> GetRating()
        {
            return _context.EmployeeRating.ToList();
        }
    }
}