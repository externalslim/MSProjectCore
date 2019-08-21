using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MS.Application.Services.QueryService;
using MS.Helper.Dtos.Queries;

namespace MS.API.Controllers
{
    [Authorize]
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class QueryController : ControllerBase
    {
        private IQueriesService _queriesService;

        public QueryController(IQueriesService queriesService)
        {
            _queriesService = queriesService;
        }

        [HttpGet]
        public QueriesOutput GetAllQueries()
        {
            var output = new QueriesOutput();
            output = _queriesService.GetAllQueries();
            return output;
        }


        [HttpGet]
        public QueriesOutput GetAllActiveQueries()
        {
            var output = new QueriesOutput();
            output = _queriesService.GetAllActiveQueries();
            return output;
        }


        [HttpPost]
        public QueriesOutput GetQueryById(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesService.GetQueryById(input);
            return output;
        }


        [HttpGet]
        public QueriesOutput GetAllQueriesWithTypes()
        {
            var output = new QueriesOutput();
            output = _queriesService.GetAllQueriesWithTypes();
            return output;
        }


        [HttpGet]
        public QueriesOutput GetAllActiveQueriesWithTypes()
        {
            var output = new QueriesOutput();
            output = _queriesService.GetAllActiveQueriesWithTypes();
            return output;
        }

        [HttpPost]
        public QueriesOutput GetAllQueriesByTypeId(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesService.GetAllQueriesByTypeId(input);
            return output;
        }

        [HttpPost]
        public QueriesOutput GetAllActiveQueriesByTypeId(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesService.GetAllActiveQueriesByTypeId(input);
            return output;
        }

        [HttpPost]
        public QueriesOutput GetQueryWithTypeByQueryId(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesService.GetQueryWithTypeByQueryId(input);
            return output;
        }

        [HttpPost]
        public QueriesOutput CreateQuery(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesService.CreateQuery(input);
            return output;
        }

        [HttpPost]
        public QueriesOutput UpdateQuery(QueriesInput input)
        {
            var output = new QueriesOutput();
            output = _queriesService.UpdateQuery(input);
            return output;
        }

        [HttpPost]
        public bool DeleteQuery(QueriesInput input)
        {
            return _queriesService.DeleteQuery(input);
        }
    }
}