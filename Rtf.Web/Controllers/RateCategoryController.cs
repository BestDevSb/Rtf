using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Rtf.Web.Controllers
{
    using Data.Abstractions.Repository;
    using DTO;

    /// <summary>
    /// категории
    /// </summary>
    
    public class RateCategoryController: Controller
    {
        private IRateCategoryRepository _repository;
        public RateCategoryController(IRateCategoryRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Добавить категорию
        /// </summary>
        /// <param name="dto">Категория</param>        
        [HttpPost("/ratecategory/")]
        public void Add(RateCategoryDto dto)
        {
            _repository.Add(dto.Name);
        }

        /// <summary>
        /// Все категории
        /// </summary>
        [HttpGet("/ratecategory/")]
        public IEnumerable<RateCategoryDto> List()
        {
            return _repository.List().Select(cat=> new RateCategoryDto { Id = cat.Id, Name = cat.Name });
        }
    }
}
