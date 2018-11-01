using System;
using System.Linq;
using Microsoft.AspNetCore.Mvc;

namespace RtfWebApp.Controllers.Api
{    
    using Data;
    using RtfWebApp.Models;
    using RtfWebApp.Services;
    using System.Collections.Generic;
    using System.Threading.Tasks;

    public class RateController:ApiBaseController<Rating>
    {
        private readonly ISettingsService _settingsService;

        private const double DefaultWeight = 0.5;

        public RateController(ApplicationDbContext context, ISettingsService settingsService):base(context)
        {
            _settingsService = settingsService ?? throw new ArgumentNullException(nameof(settingsService));
        }

        /// <summary>
        /// Базовый метод для заполнения навыков HR'ом
        /// Значение веса оценки заполняется значение поумолчанию
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("api/[controller]/")]
        public override Rating Add([FromBody]Rating entity)
        {
            entity.Weight = _settingsService.HRDefaultRate;
            return base.Add(entity);
        }

        [HttpPost("api/[controller]/ratings")]
        public async Task<IEnumerable<Rating>> Ratings([FromBody]IEnumerable<Rating> ratings)
        {
            if (ratings == null)
                return ratings;
            foreach(Rating r in ratings)
            {
                r.Weight = _settingsService.HRDefaultRate;
            }

            return await base.AddRange(ratings);
        }

        /// <summary>
        /// Рассчет веса оценки на основе данных пользоавтеля
        /// </summary>
        /// <param name="entity"></param>
        /// <returns></returns>
        [HttpPost("api/[controller]/Rate/{employeeId}")]
        public Rating Rate([FromBody]Rating entity, int employeeId)
        {
            entity.Weight = _context.EmployeeRating.FirstOrDefault(er => er.EmployeeId == employeeId && er.SkillId == entity.SkillId)?.Weight ?? 0.5;
            return base.Add(entity);
        }

        private double CalcRate(Rating entity, int employeeId)
        {
            //TODO: calc weight by user skils and reliability
            return DefaultWeight;
        }
    }
}
