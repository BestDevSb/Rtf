using System.Linq;
using System.Collections.Generic;
using Microsoft.AspNetCore.Mvc;

namespace Rtf.Web.Controllers
{
    using Data.Abstractions.Repository;
    using DTO;

    /// <summary>
    /// Отзывы
    /// </summary>    
    public class FeedbackController: Controller
    {
        private IFeedbackRepository _repository;

        public FeedbackController(IFeedbackRepository repository)
        {
            _repository = repository;
        }

        /// <summary>
        /// Добавить отзыв
        /// </summary>
        /// <param name="dto">Отзыв</param>        
        [HttpPost("/feedback/")]
        public void Add(FeedBackDto dto)
        {
            _repository.AddFeedBack(dto.From, dto.To, dto.Rate, dto.Category);
        }

        /// <summary>
        /// Все отзывы пользователя
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet("/feedback/{userid}")]
        public IEnumerable<FeedBackDto> GetUserFeedbacks(int userid)
        {
            return _repository.GetUserFeedBacks(userid).Select(feed => new FeedBackDto { From = feed.From.Id, Category = feed.Category.Id, Rate = feed.Rate, To = userid });
        }

        /// <summary>
        /// Все отзывы
        /// </summary>
        /// <returns>Отзывы</returns>
        [HttpGet("/feedback")]
        public IEnumerable<FeedBackDto> All()
        {
            return _repository.All().Select(feed => new FeedBackDto { From = feed.From.Id, Category = feed.Category.Id, Rate = feed.Rate, To = feed.To.Id });
        }
    }
}
