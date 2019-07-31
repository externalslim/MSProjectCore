using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Application.Services.QueryService
{
    public class QueriesService : IQueriesService
    {
        private IQueriesRepository _queriesRepository;
        private ITypesRepository _typesRepository;
        private IMapper _mapper;
        public QueriesService(
            IQueriesRepository queriesRepository,
            ITypesRepository typesRepository,
            IMapper mapper)
        {
            _queriesRepository = queriesRepository;
            _typesRepository = typesRepository;
            _mapper = mapper;
        }



        #region Read
        public QueriesOutput GetAllActiveQueries()
        {
            var output = new QueriesOutput();
            output = _queriesRepository.GetAllActiveQueries();
            return output;
        }

        public QueriesOutput GetAllQueries()
        {
            var output = new QueriesOutput();
            output = _queriesRepository.GetAllQueries();
            return output;
        }

        public QueriesOutput GetQueryById(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesRepository.GetQueryById(input);
            return output;
        }

        public QueriesOutput GetAllQueriesWithTypes()
        {
            var output = new QueriesOutput();

            output = _queriesRepository.GetAllQueries();
            var typeIdList = output.QueriesListModel.Select(x => x.TypeId).ToList();
            if (typeIdList.Count > 0)
            {
                TypeFilter(typeIdList, output);

            }
            return output;
        }

        public QueriesOutput GetAllActiveQueriesWithTypes()
        {
            var output = new QueriesOutput();

            output = _queriesRepository.GetAllActiveQueries();
            var typeIdList = output.QueriesListModel.Select(x => x.TypeId).ToList();

            if (typeIdList.Count > 0)
            {
                TypeFilter(typeIdList, output);
            }
            return output;
        }

        public QueriesOutput GetQueryWithTypeByQueryId(QueriesInput input)
        {
            var output = new QueriesOutput();

            output = _queriesRepository.GetQueryById(input);
            if (output.QueriesModel != null)
            {
                var typeId = output.QueriesModel.TypeId;
                if (typeId.HasValue && typeId > 0)
                {
                    var typeInput = new TypesInput();
                    typeInput.Id = typeId.Value;
                    var type = _typesRepository.GetTypeById(typeInput);
                    if (type.TypesModel != null)
                    {
                        var typeDto = new TypesDto();
                        typeDto = _mapper.Map<TypesDto>(type.TypesModel);
                        output.QueriesModel.TypeModel = typeDto;
                    }
                }
            }
            return output;
        }


        public QueriesOutput GetAllQueriesByTypeId(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesRepository.GetAllQueriesByTypeId(input);
            return output;
        }

        public QueriesOutput GetAllActiveQueriesByTypeId(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesRepository.GetAllActiveQueriesByTypeId(input);
            return output;
        }
        #endregion


        #region Create, Update, Delete
        public QueriesOutput CreateQuery(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesRepository.CreateQuery(input);
            return output;
        }
        public QueriesOutput UpdateQuery(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesRepository.UpdateQuery(input);
            return output;
        }
        public bool DeleteQuery(QueriesInput input)
        {
            return _queriesRepository.DeleteQuery(input);
        }
        #endregion

        #region Extends
        private void TypeFilter(List<int?> typeIdList, QueriesOutput output)
        {
            var types = _typesRepository.GetAllTypes().TypesListModel;
            if (types != null)
            {
                var typeFiltered = types.Where(x => typeIdList.Contains(x.Id));
                foreach (var query in output.QueriesListModel)
                {
                    query.TypeModel = types.Where(x => x.Id == query.TypeId).SingleOrDefault();
                }
            }
        }
        #endregion
    }
}
