using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MS.Application.Services.TemplateService;
using MS.Core.RepositoryBase.Contract;
using MS.Helper.Dtos.Templates;

namespace MS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class TemplateController : ControllerBase
    {
        private ITemplatesService _templatesService;

        public TemplateController(ITemplatesService templatesService)
        {
            _templatesService = templatesService;
        }

        [HttpGet]
        public TemplatesOutput GetAllTemplates()
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetAllTemplates();
            return output;
        }


        [HttpGet]
        public TemplatesOutput GetAllActiveTemplates()
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetAllActiveTemplates();
            return output;
        }


        [HttpPost]
        public TemplatesOutput GetTemplateById(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetTemplateById(input);
            return output;
        }


        [HttpGet]
        public TemplatesOutput GetAllTemplatesWithTypes()
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetAllTemplatesWithTypes();
            return output;
        }


        [HttpGet]
        public TemplatesOutput GetAllActiveTemplatesWithTypes()
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetAllActiveTemplatesWithTypes();
            return output;
        }

        [HttpPost]
        public TemplatesOutput GetAllTemplatesByTypeId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetAllTemplatesByTypeId(input);
            return output;
        }

        [HttpPost]
        public TemplatesOutput GetAllActiveTemplatesByTypeId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetAllActiveTemplatesByTypeId(input);
            return output;
        }


        [HttpPost]
        public TemplatesOutput GetTemplateWithTypeByTemplateId(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesService.GetTemplateWithTypeByTemplateId(input);
            return output;
        }

        [HttpPost]
        public TemplatesOutput CreateTemplate(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesService.CreateTemplate(input);
            return output;
        }

        [HttpPost]
        public TemplatesOutput UpdateTemplate(TemplatesInput input)
        {
            var output = new TemplatesOutput();
            output = _templatesService.UpdateTemplate(input);
            return output;
        }

        [HttpPost]
        public bool DeleteTemplate(TemplatesInput input)
        {
            return _templatesService.DeleteTemplate(input);
        }
    }
}