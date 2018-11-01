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

    public class RateController:ApiBaseController<Rating>
    {
        private const double DefaultWeight = 0.5;

        public RateController(ApplicationDbContext context):base(context)
        { }

        /// <summary>
        /// Базовый метод для заполнения навыков HR'ом
        /// Значение веса оценки заполняется значение поумолчанию
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("api/[controller]/")]
        public override Rating Add(Rating entity)
        {
            entity.Weight = DefaultWeight;
            return base.Add(entity);
        }

        /// <summary>
        /// Рассчет веса оценки на основе данных пользоавтеля
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("api/[controller]/Rate/{employeeId}")]
        public Rating Rate(Rating entity, int employeeId)
        {
            entity.Weight = CalcRate(entity, employeeId);
            return base.Add(entity);
        }

        private double CalcRate(Rating entity, int employeeId)
        {
            //TODO: calc weight by user skils and reliability
            return DefaultWeight;
        }
    }
}
