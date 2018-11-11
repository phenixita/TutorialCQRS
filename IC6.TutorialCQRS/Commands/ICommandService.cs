using IC6.TutorialCQRS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC6.TutorialCQRS.Commands
{
    public interface ICommandService
    {
        Task<Post> SavePost(string title, string body);
    }
}
