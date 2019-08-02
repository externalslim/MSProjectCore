using MS.Application.DependencyManager;
using MS.Helper.Dtos.Instants;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services.InstantService
{
    public interface IInstantService : IServiceDependency
    {
        InstantsOutput GetAllInstants();
        InstantsOutput GetAllInstantsWithTypeTemplateQuery();
        InstantsOutput GetAllActiveInstants();
        InstantsOutput GetAllActiveInstantsWithTypeTemplateQuery();

        InstantsOutput GetInstantByIdFilter(InstantsInput input);
        InstantsOutput GetInstantByIdFilterWithTypeTemplateQuery(InstantsInput input);

        InstantsOutput CreateInstant(InstantsInput input);
        InstantsOutput UpdateInstant(InstantsInput input);
        bool DeleteInstant(InstantsInput input);
    }
}
