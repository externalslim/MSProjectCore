using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Core.UoW;
using MS.Data.Models;
using MS.Helper.Dtos.Instants;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;
using System.Collections.Generic;
using System.Linq;

namespace MS.Application.Services.InstantService
{
    public class InstantService : IInstantService
    {
        private IInstantsRepository _instantsRepository;
        private ITypesRepository _typesRepository;
        private ITemplatesRepository _templatesRepository;
        private IQueriesRepository _queriesRepository;
        private IMapper _mapper;

        public InstantService(
            IInstantsRepository instantsRepository,
            ITypesRepository typesRepository,
            ITemplatesRepository templatesRepository,
            IQueriesRepository queriesRepository,
            IMapper mapper
            )
        {
            _instantsRepository = instantsRepository;
            _typesRepository = typesRepository;
            _templatesRepository = templatesRepository;
            _queriesRepository = queriesRepository;
            _mapper = mapper;
        }

        #region GetList
        public InstantsOutput GetAllInstants()
        {
            var output = new InstantsOutput();
            output = _instantsRepository.GetAllInstants();
            return output;
        }

        public InstantsOutput GetAllActiveInstants()
        {
            var output = new InstantsOutput();
            output = _instantsRepository.GetAllActiveInstants();
            return output;
        }

        public InstantsOutput GetInstantByIdFilter(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantsRepository.GetInstantByIdFilter(input);
            return output;
        }
        #endregion

        #region Create, Update, Delete
        [UnitOfWork]
        public InstantsOutput CreateInstant(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantsRepository.CreateInstant(input);
            return output;
        }
        public InstantsOutput UpdateInstant(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = _instantsRepository.UpdateInstant(input);
            return output;
        }

        public bool DeleteInstant(InstantsInput input)
        {
            return _instantsRepository.DeleteInstant(input);
        }



        public InstantsOutput GetAllInstantsWithTypeTemplateQuery()
        {
            var output = new InstantsOutput();

            var instants = _instantsRepository.GetAllInstants();
            if (instants.InstantsListModel.Count > 0)
            {
                output = Navigator(output);
            }

            return output;
        }

        public InstantsOutput GetAllActiveInstantsWithTypeTemplateQuery()
        {
            var output = new InstantsOutput();

            var instants = _instantsRepository.GetAllActiveInstants();
            if (instants.InstantsListModel.Count > 0)
            {
                output = Navigator(output);
            }

            return output;
        }

        public InstantsOutput GetInstantByIdFilterWithTypeTemplateQuery(InstantsInput input)
        {
            var output = new InstantsOutput();
            output = FilteredInstants(input);
            output = Navigator(output);
            return output;
        }
        #endregion

        #region Extends
        private InstantsOutput FilteredInstants(InstantsInput input)
        {
            var output = new InstantsOutput();
            var instants = _instantsRepository.GetAllInstants();
            instants = GetInstantByIdFilter(input);
            output = Navigator(instants);
            return output;
        }

        private InstantsOutput Navigator(InstantsOutput input)
        {
            var output = input;

            if (output.InstantsListModel != null && output.InstantsListModel.Count > 0)
            {
                //templates
                var templateIdList = output.InstantsListModel.Select(x => x.TemplateId);
                var templates = _templatesRepository.GetAll();

                var filteredTemplates = new List<Templates>();
                if (templateIdList.Count() > 0 && templates.Count > 0)
                {
                    filteredTemplates = templates.Where(x => templateIdList.Contains(x.Id)).ToList();
                }
                //templates

                //queries
                var queryIdList = output.InstantsListModel.Select(x => x.QueryId);
                var queries = _queriesRepository.GetAll();

                var filteredQueries = new List<Queries>();
                if (queryIdList.Count() > 0 && queries.Count > 0)
                {
                    filteredQueries = queries.Where(x => queryIdList.Contains(x.Id)).ToList();
                }
                //queries

                //types
                var typeIdList = output.InstantsListModel.Select(x => x.TypeId);
                var types = _typesRepository.GetAll();

                var filteredTypes = new List<Types>();
                if (typeIdList.Count() > 0 && types.Count > 0)
                {
                    filteredTypes = types.Where(x => typeIdList.Contains(x.Id)).ToList();
                }
                //types

                foreach (var instant in output.InstantsListModel)
                {

                    var selectedTemplate = filteredTemplates.Where(x => x.Id == instant.TemplateId).SingleOrDefault();
                    instant.TemplatesModel = selectedTemplate != null ? _mapper.Map<TemplatesDto>(selectedTemplate) : null;

                    var selectedQuery = filteredQueries.Where(x => x.Id == instant.QueryId).SingleOrDefault();
                    instant.QueriesModel = selectedQuery != null ? _mapper.Map<QueriesDto>(selectedQuery) : null;

                    var selectedType = filteredTypes.Where(x => x.Id == instant.TypeId).SingleOrDefault();
                    instant.TypesModel = selectedType != null ? _mapper.Map<TypesDto>(selectedType) : null;
                }
            }
            else
            {
                //template
                var templateInput = new TemplatesInput();
                var templateId = output.InstantsModel.TemplateId;
                templateInput.Id = templateId.Value;
                var template = _templatesRepository.GetTemplateById(templateInput);
                output.InstantsModel.TemplatesModel = _mapper.Map<TemplatesDto>(template.TemplatesModel);
                //template

                //query
                var queryInput = new QueriesInput();
                var queryId = output.InstantsModel.QueryId;
                queryInput.Id = queryId.Value;
                var query = _queriesRepository.GetQueryById(queryInput);
                output.InstantsModel.QueriesModel = _mapper.Map<QueriesDto>(query.QueriesModel);
                //query

                //type
                var typeInput = new TypesInput();
                var typeId = output.InstantsModel.QueryId;
                typeInput.Id = typeId.Value;
                var type = _typesRepository.GetTypeById(typeInput);
                output.InstantsModel.TypesModel = _mapper.Map<TypesDto>(type.TypesModel);
                //type

            }

            return output;
        }
        #endregion
    }
}
