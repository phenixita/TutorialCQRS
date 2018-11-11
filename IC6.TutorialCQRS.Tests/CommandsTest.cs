using IC6.TutorialCQRS.Commands;
using IC6.TutorialCQRS.Model;
using Microsoft.EntityFrameworkCore;
using System.Threading.Tasks;
using Xunit;

namespace IC6.TutorialCQRS.Tests
{
    public class CommandsTest
    {
        [Fact]
        public async Task Test1()
        {
            //Assemble

            var options = new DbContextOptionsBuilder<BlogContext>()
                .UseInMemoryDatabase(databaseName: "mem-test")
                .Options;

            Post post;
            using (var context = new BlogContext(options))
            {
                var commands = new CommandService(context);

                //act
                post = await commands.SavePost("Title", "Body");
            }

            using (var context = new BlogContext(options))
            {
                //Assert
                Assert.True(await context.Posts.AnyAsync(p => p.Id == post.Id));
            }
        }
    }
}
