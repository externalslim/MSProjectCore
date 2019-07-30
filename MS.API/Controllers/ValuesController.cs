using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using MS.Application.DependencyResolver;
using MS.Application.Services.TypesService;
using MS.Core.UoW;
using MS.Data.Models;
using MS.Helper.Dtos.Instants;

namespace MS.API.Controllers
{
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
        [UnitOfWork]
        public ActionResult<IEnumerable<string>> Get()
        {
            var types = _typesService.GetAllTypes();

            return new string[] { "value1", "value2" };
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
