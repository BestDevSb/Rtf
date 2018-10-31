using System.Collections.Generic;
using Rtf.Data.Model;

namespace Rtf.Data.Abstractions.Repository
{
    public interface IRateCategoryRepository
    {
        void Add(string name);
        IEnumerable<RateCategory> List();
    }
}