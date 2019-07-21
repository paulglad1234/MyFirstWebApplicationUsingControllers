using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplicationUsingControllers.Services;

namespace MyFirstWebApplicationUsingControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values1Controller : Controller
    {
        private readonly IDataWorker _dataWorker;

        public Values1Controller(IDataWorker dataWorker)
        {
            _dataWorker = dataWorker;
        }

        public class GetRequest
        {
            public int From { get; set; }
            public int Till { get; set; }
        }
        // GET api/values1
        [HttpGet]
        public object Get([FromBody] GetRequest value)
        {
            return new
            {
                Sum = _dataWorker.GetSum(value.From, value.Till)
            };
        }

        // POST api/values1
        [HttpPost]
        public void Post([FromBody] PostRequest value)
        {
            _dataWorker.AddData(value.Value);
        }

        public class PostRequest
        {
            public int Value { get; set; }
        }
    }
}
