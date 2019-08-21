using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Application.Services.InstantService;
using MS.Helper.Dtos.Instants;

namespace MS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class InstantController : ControllerBase
    {
        private IInstantService _instantService;
        public InstantController(IInstantService instantService)
        {
            _instantService = instantService;
        }


        [HttpGet]
        public InstantsOutput GetAllInstants()
        {
            var output = new InstantsOutput();
            output = _instantService.GetAllInstants();
            return output;
        }


        [HttpGet]
        public InstantsOutput GetAllInstantsWithTypeTemplateQuery()
        {
            var output = new InstantsOutput();
            output = _instantService.GetAllInstantsWithTypeTemplateQuery();
            return output;
        }

        [HttpGet]
        public InstantsOutput GetAllActiveInstants()
        {
            var output = new InstantsOutput();
            output = _instantService.GetAllActiveInstants();
            return output;
        }

        [HttpGet]
        public InstantsOutput GetAllActiveInstantsWithTypeTemplateQuery()
        {
            var output = new InstantsOutput();
            output = _instantService.GetAllActiveInstantsWithTypeTemplateQuery();
            return output;
        }

        [HttpPost]
        public InstantsOutput GetInstantByIdFilter(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantService.GetInstantByIdFilter(input);
            return output;
        }

        [HttpPost]
        public InstantsOutput GetInstantByIdFilterWithTypeTemplateQuery(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantService.GetInstantByIdFilterWithTypeTemplateQuery(input);
            return output;
        }

        [HttpPost]
        public InstantsOutput CreateInstant(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantService.CreateInstant(input);
            return output;
        }

        [HttpPost]
        public InstantsOutput UpdateInstant(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantService.UpdateInstant(input);
            return output;
        }

        [HttpPost]
        public bool DeleteInstant(InstantsInput input)
        {
            return _instantService.DeleteInstant(input);
        }
    }
}