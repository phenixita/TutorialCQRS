using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC6.TutorialCQRS.Queries
{
    public interface IQueriesService
    {
        Task<IEnumerable<int>> GetAllPostId();
    }
}
