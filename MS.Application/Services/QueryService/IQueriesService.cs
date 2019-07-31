using MS.Application.DependencyManager;
using MS.Helper.Dtos.Queries;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services.QueryService
{
    public interface IQueriesService : IServiceDependency
    {
        QueriesOutput GetAllQueries();
        QueriesOutput GetAllActiveQueries();
        QueriesOutput GetQueryById(QueriesInput input);
        QueriesOutput GetAllQueriesWithTypes();
        QueriesOutput GetAllActiveQueriesWithTypes();
        QueriesOutput GetQueryWithTypeByQueryId(QueriesInput input);
        QueriesOutput GetAllQueriesByTypeId(QueriesInput input);
        QueriesOutput GetAllActiveQueriesByTypeId(QueriesInput input);

        QueriesOutput CreateQuery(QueriesInput input);
        QueriesOutput UpdateQuery(QueriesInput input);
        bool DeleteQuery(QueriesInput input);
    }
}
