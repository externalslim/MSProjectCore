using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Application.Services.TypeService;
using MS.Helper.Dtos.Types;

namespace MS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {

        private ITypesService _typesService;

        public ValuesController(ITypesService typesService)
        {
            _typesService = typesService;
        }
        
        // GET api/values
        [HttpGet]
        public ActionResult<TypesOutput> Get()
        {
            var types = _typesService.GetAllTypes();
            //return Newtonsoft.Json.JsonConvert.DeserializeObject(types);
            return types;
        }

        // GET api/values/5
        [HttpGet("{id}")]
        public ActionResult<string> Get(int id)
        {
            return "value";
        }

        // POST api/values
        [HttpPost]
        public void Post([FromBody] string value)
        {
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
