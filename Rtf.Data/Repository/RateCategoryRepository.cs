using System.Linq;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

namespace Rtf.Data.Repository
{
    using Abstractions.DataContext;
    using Abstractions.Repository;
    using Model;

    public class RateCategoryRepository : IRateCategoryRepository
    {
        private IDataContext _context;
        private IQueryable<RateCategory> _rateCategories;

        public RateCategoryRepository(IDataContext context)
        {
            _context = context;
            _rateCategories = _context.Query<RateCategory>();
        }

        public void Add(string name)
        {
            _context.Add(new RateCategory { Name = name } );
            _context.SaveChanges();
        }

        public IEnumerable<RateCategory> List()
        {
            return _rateCategories
                .ToList();
        }
    }
}
