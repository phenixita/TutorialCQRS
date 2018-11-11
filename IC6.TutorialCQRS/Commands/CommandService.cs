using IC6.TutorialCQRS.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC6.TutorialCQRS.Commands
{
    public class CommandService : ICommandService
    {
        private readonly BlogContext _context;

        public CommandService(BlogContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public async Task<Post> SavePost(string title, string body)
        {
            var newPost = new Post() { Title = title, Body = body };

            await _context.Posts.AddAsync(newPost);

            await _context.SaveChangesAsync();

            return newPost;
        }
    }
}
