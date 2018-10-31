using System.Collections.Generic;
using Rtf.Data.Model;

namespace Rtf.Data.Abstractions.Repository
{
    public interface IFeedbackRepository
    {
        IEnumerable<FeedBack> GetUserFeedBacks(int id);
        
        FeedBack AddFeedBack(int from, int to, int rate, int category);

        IEnumerable<FeedBack> All();
    }
}