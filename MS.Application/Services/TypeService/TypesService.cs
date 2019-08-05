using System;
using System.Collections.Generic;
using System.Text;
using MS.Application.DependencyManager;
using MS.Core.RepositoryBase.Contract;
using MS.Core.UoW;
using MS.Helper.Dtos.Types;

namespace MS.Application.Services.TypeService
{
    public class TypesService : ITypesService
    {
        private ITypesRepository _typesRepository;
        public TypesService(ITypesRepository typesRepository)
        {
            _typesRepository = typesRepository;
        }

        public TypesOutput GetActiveTypes()
        {
            var output = new TypesOutput();
            output = _typesRepository.GetActiveTypes();
            return output;
        }

        public TypesOutput GetAllTypes()
        {
            var output = new TypesOutput();
            output = _typesRepository.GetAllTypes();
            return output;
        }

        public TypesOutput GetTypeById(TypesInput input)
        {
            var output = new TypesOutput();
            output = _typesRepository.GetTypeById(input);
            return output;
        }
    }
}
