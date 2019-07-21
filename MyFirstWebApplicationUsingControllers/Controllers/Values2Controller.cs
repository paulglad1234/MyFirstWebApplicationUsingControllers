using Microsoft.AspNetCore.Mvc;
using MyFirstWebApplicationUsingControllers.Services;
using Newtonsoft.Json;

namespace MyFirstWebApplicationUsingControllers.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Values2Controller : Controller
    {
        private readonly IDataWorker _dataWorker;

        public Values2Controller(IDataWorker dataWorker)
        {
            _dataWorker = dataWorker;
        }

        // GET api/values2
        [HttpGet]
        public JsonResult Get()
        {
            dynamic jsonRequest = GetJsonRequest();
            return jsonRequest == null
                ? Json("Hello, World!")
                : Json(_dataWorker.GetSum((int) jsonRequest.from, (int) jsonRequest.till));
        }

        // POST api/values2
        [HttpPost]
        public void Post()
        {
            dynamic jsonRequest = GetJsonRequest();
            _dataWorker.AddData((int)jsonRequest.value);
        }

        private dynamic GetJsonRequest()
        {
            var request = RequestBodyConverter.BodyToString(Request);
            return string.IsNullOrEmpty(request) ? null : JsonConvert.DeserializeObject(request);
        }
    }
}