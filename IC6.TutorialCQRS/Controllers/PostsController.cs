using IC6.TutorialCQRS.Commands;
using IC6.TutorialCQRS.Queries;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace IC6.TutorialCQRS.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PostsController : ControllerBase
    {
        private readonly IQueriesService _queries;
        private readonly ICommandService _commands;

        public PostsController(IQueriesService queries, ICommandService commands)
        {
            _queries = queries ?? throw new ArgumentNullException(nameof(queries));
            _commands = commands ?? throw new ArgumentNullException(nameof(commands));
        }

        // GET api/values
        [HttpGet]
        public async Task<ActionResult<IEnumerable<int>>> Get()
        {
            return (await _queries.GetAllPostId()).ToList();
        }

       

        // POST api/values
        [HttpPost]
        public void SavePost([FromBody] SavePostDto value)
        {
            _commands.SavePost(value.Title, value.Body);
        }
         
    }
}
