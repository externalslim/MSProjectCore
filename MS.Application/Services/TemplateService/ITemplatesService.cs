using MS.Application.DependencyManager;
using MS.Helper.Dtos.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services.TemplateService
{
    public interface ITemplatesService : IServiceDependency
    {
        TemplatesOutput GetAllTemplates();
        TemplatesOutput GetAllActiveTemplates();
        TemplatesOutput GetTemplateById(TemplatesInput input);

        TemplatesOutput GetAllTemplatesWithTypes();
        TemplatesOutput GetAllActiveTemplatesWithTypes();
        TemplatesOutput GetTemplateWithTypeByTemplateId(TemplatesInput input);

        TemplatesOutput CreateTemplate(TemplatesInput input);
        TemplatesOutput UpdateTemplate(TemplatesInput input);
        bool DeleteTemplate(TemplatesInput input);
    }
}
