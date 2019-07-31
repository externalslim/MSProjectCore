using MS.Core.RepositoryBase.DependencyManager;
using MS.Data.Models;
using MS.Helper.Dtos.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Contract
{
    public interface IQueriesRepository : IRepository<Queries>, IRepositoryDependency
    {
        QueriesOutput GetAllQueries();
        QueriesOutput GetAllActiveQueries();
        QueriesOutput GetAllQueriesByTypeId(QueriesInput input);
        QueriesOutput GetAllActiveQueriesByTypeId(QueriesInput input);
        QueriesOutput GetQueryById(QueriesInput input);
        QueriesOutput CreateQuery(QueriesInput input);
        QueriesOutput UpdateQuery(QueriesInput input);
        bool DeleteQuery(QueriesInput input);
    }
}
