using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rtf.Data.Repository
{
    using Abstractions.DataContext;
    using Abstractions.Repository;
    using Model;

    public class FeedbackRepository : IFeedbackRepository
    {
        private IDataContext _context;
        private IQueryable<FeedBack> _feedBacks;

        public FeedbackRepository(IDataContext context)
        {
            _context = context;
            _feedBacks = _context.Query<FeedBack>();
        }

        public void SaveFeedback(FeedBack entity)
        {
            _context.Add(entity);
            _context.SaveChanges();
        }

        public IEnumerable<FeedBack> GetUserFeedBacks(int id)
        {
            return _feedBacks                
                .Include(feedback => feedback.From)
                .Include(feedback => feedback.To)
                .Include(FeedBack => FeedBack.Category)
                .Where(feedback => feedback.To.Id == id)                
                .ToList();
        }

        public IEnumerable<FeedBack> All()
        {
            return _feedBacks
                .Include(feedback => feedback.From)
                .Include(feedback => feedback.To)
                .Include(FeedBack => FeedBack.Category)
                .ToList();
        }

        public FeedBack AddFeedBack(int from, int to, int rate, int category)
        {
            var feedback = new FeedBack
            {
                From = _context.Query<User>().FirstOrDefault(user => user.Id == from),
                To = _context.Query<User>().FirstOrDefault(user => user.Id == to),
                Category = _context.Query<RateCategory>().FirstOrDefault(cat => cat.Id == category),
                Rate = rate
            };
            SaveFeedback(feedback);
            return feedback;
        }

    }
}
