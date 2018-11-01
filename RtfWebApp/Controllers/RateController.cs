using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RtfWebApp.Controllers
{    
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
        public override Rating Add([FromBody]Rating entity)
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
        public Rating Rate([FromBody]Rating entity, int employeeId)
        {
            entity.Weight = _context.EmployeeRating.FirstOrDefault(er => er.EmployeeId == employeeId && er.SkillId == entity.SkillId)?.Weight ?? 0.1;
            return base.Add(entity);
        }

        private double CalcRate(Rating entity, int employeeId)
        {
            //TODO: calc weight by user skils and reliability
            return DefaultWeight;
        }
    }
}
