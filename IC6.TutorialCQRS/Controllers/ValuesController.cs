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
    public class ValuesController : ControllerBase
    {
        private readonly IValueQueriesService _queries;
        private readonly IValueCommandService _commands;

        public ValuesController(IValueQueriesService queries, IValueCommandService commands)
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

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void SavePost([FromBody] SavePostDto value)
        {
            _commands.SavePost(value.Title, value.Body);
        }

        // PUT api/values/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/values/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
