using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Data.Models;
using MS.Helper.Dtos.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Base
{
    public class QueriesRepository : Repository<Queries>, IQueriesRepository
    {
        private readonly IMapper _mapper;

        public QueriesRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Read
        public QueriesOutput GetAllActiveQueries()
        {
            var output = new QueriesOutput();

            var Queries = GetAllWithFilter(x => !x.IsDeleted);
            if (Queries.Count > 0)
            {
                output.QueriesListModel = _mapper.Map<List<QueriesDto>>(Queries);
            }

            return output;
        }

        public QueriesOutput GetAllQueries()
        {
            var output = new QueriesOutput();

            var Queries = GetAll();
            if (Queries.Count > 0)
            {
                output.QueriesListModel = _mapper.Map<List<QueriesDto>>(Queries);
            }

            return output;
        }

        public QueriesOutput GetQueryById(QueriesInput input)
        {
            var output = new QueriesOutput();

            var Query = GetWithFilter(x => x.Id == input.Id);
            if (Query != null)
            {
                output.QueriesModel = _mapper.Map<QueriesDto>(Query);
            }

            return output;
        }

        public QueriesOutput GetAllQueriesByTypeId(QueriesInput input)
        {
            var output = new QueriesOutput();
            var Queries = GetAllWithFilter(x => x.TypeId == input.TypeId);
            if (Queries.Count > 0)
            {
                output.QueriesListModel = _mapper.Map<List<QueriesDto>>(Queries);
            }
            return output;
        }

        public QueriesOutput GetAllActiveQueriesByTypeId(QueriesInput input)
        {
            var output = new QueriesOutput();
            var Queries = GetAllWithFilter(x => x.TypeId == input.TypeId && !x.IsDeleted);
            if (Queries.Count > 0)
            {
                output.QueriesListModel = _mapper.Map<List<QueriesDto>>(Queries);
            }
            return output;
        }
        #endregion

        #region Create, Update, Delete
        public QueriesOutput CreateQuery(QueriesInput input)
        {
            var output = new QueriesOutput();

            var Query = Create(_mapper.Map<Queries>(input));
            if (Query != null)
            {
                output.QueriesModel = _mapper.Map<QueriesDto>(Query);
            }

            return output;
        }

        public QueriesOutput UpdateQuery(QueriesInput input)
        {
            var output = new QueriesOutput();
            Update(_mapper.Map<Queries>(input));
            var Query = GetWithFilter(x => x.Id == input.Id);
            output.QueriesModel = _mapper.Map<QueriesDto>(Query);
            return output;
        }

        public bool DeleteQuery(QueriesInput input)
        {
            return Delete(_mapper.Map<Queries>(input));
        }
        #endregion
    }
}
