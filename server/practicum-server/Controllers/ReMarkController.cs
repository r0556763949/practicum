using Microsoft.AspNetCore.Mvc;
using Practicum.Service.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace practicum_server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReMarkController : ControllerBase
    {
        private readonly ReMarkService _reMarkService;
        public ReMarkController(ReMarkService remarkService)
        {
            _reMarkService = remarkService;
        }
        // GET: api/<RemarkController>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            return new string[] { "value1", "value2" };
        }

        // GET api/<RemarkController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<RemarkController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<RemarkController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<RemarkController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
