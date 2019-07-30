using MS.Application.DependencyManager;
using MS.Core.RepositoryBase.DependencyManager;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services.TypesService
{
    public interface ITypesService : IServiceDependency
    {
        TypesOutput GetAllTypes();
    }
}
