using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Application.Services.TypeService;
using MS.Helper.Dtos.Types;

namespace MS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TypeController : ControllerBase
    {
        private ITypesService _typesService;
        public TypeController(ITypesService typesService)
        {
            _typesService = typesService;
        }

        [HttpGet]
        public TypesOutput GetAllTypes()
        {
            var output = new TypesOutput();
            output = _typesService.GetAllTypes();
            return output;
        }

        [HttpGet]
        public TypesOutput GetAllActiveTypes()
        {
            var output = new TypesOutput();
            output = _typesService.GetActiveTypes();
            return output;
        }

        [HttpPost]
        public TypesOutput GetTypeById(TypesInput input)
        {
            var output = new TypesOutput();
            output = _typesService.GetTypeById(input);
            return output;
        }


    }
}