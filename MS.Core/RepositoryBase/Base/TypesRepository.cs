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

        public TypesOutput GetActiveTypes()
        {
            var output = new TypesOutput();
            var typeList = GetAllWithFilter(x => !x.IsDeleted);
            if (typeList.Count > 0)
            {
                output.TypesListModel = _mapper.Map<List<TypesDto>>(typeList);
            }
            return output;
        }

        public TypesOutput GetAllTypes()
        {
            var output = new TypesOutput();
            var typeList = GetAll();
            if (typeList.Count > 0)
            {
                output.TypesListModel = _mapper.Map<List<TypesDto>>(typeList);
            }
            return output;
        }

        public TypesOutput GetTypeById(TypesInput input)
        {
            var output = new TypesOutput();
            var type = GetWithFilter(x => x.Id == input.Id);
            if (type != null)
            {
                output.TypesModel = _mapper.Map<TypesDto>(type);
            }
            return output;
        }
    }
}
