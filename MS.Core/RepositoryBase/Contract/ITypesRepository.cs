using MS.Core.RepositoryBase.DependencyManager;
using MS.Data.Models;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Contract
{
    public interface ITypesRepository : IRepository<Types>, IRepositoryDependency
    {
        TypesOutput GetAllTypes();
        TypesOutput GetActiveTypes();
        TypesOutput GetTypeById(TypesInput input);
    }
}
