using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Data.Models;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Core.RepositoryBase.Base
{
    public class TypesRepository : Repository<Types>, ITypesRepository
    {
        private readonly IMapper _mapper;
        public TypesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        public TypesOutput Create(TypesInput input)
        {
            var output = new TypesOutput();
            return output;
        }

        public void Delete(TypesInput input)
        {
            throw new NotImplementedException();
        }

        public TypesOutput GetActiveTypesList()
        {
            throw new NotImplementedException();
        }

        public TypesOutput GetAllTypes()
        {
            var output = new TypesOutput();
            var types = GetAll().OrderByDescending(x => x.Id).ToList();
            if (types != null)
            {
                output.TypesListModel = _mapper.Map<List<TypesDto>>(types);
            }
            return output;
        }

        public TypesOutput GetTypesById(TypesInput input)
        {
            throw new NotImplementedException();
        }

        public void Update(TypesInput input)
        {
            throw new NotImplementedException();
        }
    }
}
