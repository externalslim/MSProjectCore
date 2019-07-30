using System;
using System.Collections.Generic;
using System.Text;
using MS.Core.RepositoryBase.Contract;
using MS.Core.UoW;
using MS.Helper.Dtos.Types;

namespace MS.Application.Services.TypesService
{
    public class TypesService : ITypesService
    {
        private ITypesRepository _typesRepository;
        public TypesService(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        [UnitOfWork]
        public TypesOutput GetAllTypes()
        {
            var output = new TypesOutput();
            output = _typesRepository.GetAllTypes();
            return output;
        }
    }
}
