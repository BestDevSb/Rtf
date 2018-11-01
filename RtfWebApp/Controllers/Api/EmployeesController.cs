using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace RtfWebApp.Controllers.Api
{
    using Models;
    using Data;
    using RtfWebApp.Models;
    using RtfWebApp.Services;

    [ApiController]
    public class EmployeesController : ApiBaseController<Employee>
    {
        private readonly IEmployeesService _service;
        
        public EmployeesController(ApplicationDbContext context, IEmployeesService service):
            base(context)
        {
            _service = service ?? throw new ArgumentNullException(nameof(service));
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

        [HttpGet("api/[controller]/getrecomendedemployees/{employeeId}")]
        public async Task<IEnumerable<RecomendedEmployees>> GetRecomendedEmployees(int employeeId)
        {
            return await _service.GetRecommendedEmployeesAsync(employeeId);
        }
    }
}