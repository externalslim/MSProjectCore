using MS.Core.RepositoryBase.DependencyManager;
using MS.Data.Models;
using MS.Helper.Dtos.Templates;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Contract
{
    public interface ITemplatesRepository : IRepository<Templates>, IRepositoryDependency
    {
        TemplatesOutput GetAllTemplates();
        TemplatesOutput GetAllActiveTemplates();
        TemplatesOutput GetTemplateById(TemplatesInput input);
        TemplatesOutput CreateTemplate(TemplatesInput input);
        TemplatesOutput UpdateTemplate(TemplatesInput input);
        bool DeleteTemplate(TemplatesInput input);
    }
}
