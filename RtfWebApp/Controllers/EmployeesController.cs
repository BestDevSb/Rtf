﻿using System;
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
        public int CalcRating(int employeeId, DateTime from, DateTime to)
        {
            return 0;
        }
    }
}