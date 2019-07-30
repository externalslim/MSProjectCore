using MS.Data.Models;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Contract
{
    public interface ITypesRepository : IRepository<Types>
    {
        TypesOutput GetAllTypes();
        TypesOutput GetActiveTypesList();
        TypesOutput GetTypesById(TypesInput input);
        TypesOutput Create(TypesInput input);
        void Update(TypesInput input);
        void Delete(TypesInput input);
    }
}
