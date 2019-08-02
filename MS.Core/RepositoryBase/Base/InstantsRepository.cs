using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Data.Models;
using MS.Helper.Dtos.Instants;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Core.RepositoryBase.Base
{
    public class InstantsRepository : Repository<Instants>, IInstantsRepository
    {
        private IQueriesRepository _queriesRepository;
        private ITemplatesRepository _templatesRepository;
        private ITypesRepository _typesRepository;

        private IMapper _mapper;
        public InstantsRepository(
            IMapper mapper,
            ITemplatesRepository templatesRepository,
            ITypesRepository typesRepository,
            IQueriesRepository queriesRepository
            )
        {
            _mapper = mapper;
            _templatesRepository = templatesRepository;
            _typesRepository = typesRepository;
            _queriesRepository = queriesRepository;
        }

        #region Get List
        public InstantsOutput GetAllInstants()
        {
            var output = new InstantsOutput();
            var instants = GetAll();
            if (instants.Count > 0)
            {
                output.InstantsListModel = _mapper.Map<List<InstantsDto>>(instants);
            }
            return output;
        }

        public InstantsOutput GetAllActiveInstants()
        {
            var output = new InstantsOutput();
            var instants = GetAllWithFilter(x => !x.IsDeleted);
            if (instants.Count > 0)
            {
                output.InstantsListModel = _mapper.Map<List<InstantsDto>>(instants);
            }
            return output;
        }       
        #endregion

        #region Get ById
        public InstantsOutput GetInstantByIdFilter(InstantsInput input)
        {
            var output = new InstantsOutput();
            if (input.Id > 0)
            {
                var instant = GetWithFilter(x => x.Id == input.Id);
                if (instant != null)
                {
                    output.InstantsModel = _mapper.Map<InstantsDto>(instant);
                }
                else
                {
                    var instantList = GetAll();
                    if (input.TemplateId != null && input.TemplateId > 0)
                    {
                        instantList = instantList.Where(x => x.TemplateId == input.TemplateId).ToList();
                    }
                    if (input.QueryId != null && input.QueryId > 0)
                    {
                        instantList = instantList.Where(x => x.QueryId == input.QueryId).ToList();
                    }
                    if (input.TypeId != null && input.TypeId > 0)
                    {
                        instantList = instantList.Where(x => x.TypeId == input.TypeId).ToList();
                    }
                    output.InstantsListModel = _mapper.Map<List<InstantsDto>>(instantList);
                    
                }
            }
            return output;
        }
        #endregion


        #region Create, Update, Delete
        public InstantsOutput CreateInstant(InstantsInput input)
        {
            var output = new InstantsOutput();
            if (input.TemplateId == null)
            {
                var template = _templatesRepository.CreateTemplate(_mapper.Map<TemplatesInput>(input.TemplatesModel));
                if (template != null)
                {
                    output.InstantsModel.TemplatesModel = template.TemplatesModel;
                    input.TemplateId = output.InstantsModel.TemplateId = template.TemplatesModel.Id;
                }
            }
            else
            {
                var templateInput = new TemplatesInput();
                templateInput.Id = input.TemplateId.Value;
                var template = _templatesRepository.GetTemplateById(templateInput);
                if (template != null)
                {
                    output.InstantsModel.TemplatesModel = template.TemplatesModel;
                }
            }

            if (input.QueryId == null)
            {
                var query = _queriesRepository.CreateQuery(_mapper.Map<QueriesInput>(input.QueriesModel));
                if (query != null)
                {
                    output.InstantsModel.QueriesModel = query.QueriesModel;
                    input.QueryId = output.InstantsModel.QueryId = query.QueriesModel.Id;
                }
            }
            else
            {
                var queryInput = new QueriesInput();
                queryInput.Id = input.QueryId.Value;
                var query = _queriesRepository.GetQueryById(queryInput);
                if (query != null)
                {
                    output.InstantsModel.QueriesModel = query.QueriesModel;
                }
            }

            var typeInput = new TypesInput();
            typeInput.Id = input.TypeId.Value;
            var type = _typesRepository.GetTypeById(typeInput);
            if (type.TypesModel != null)
            {
                output.InstantsModel.TypesModel = type.TypesModel;
                input.TypeId = type.TypesModel.Id;
            }

            var instant = Create(_mapper.Map<Instants>(input));
            if (instant != null)
            {
                output.InstantsModel = _mapper.Map<InstantsDto>(instant);
            }

            return output;

        }

        public InstantsOutput UpdateInstant(InstantsInput input)
        {
            var output = new InstantsOutput();
            Update(_mapper.Map<Instants>(input));
            var instant = GetWithFilter(x => x.Id == input.Id);
            output.InstantsModel = _mapper.Map<InstantsDto>(instant);
            return output;
        }

        public bool DeleteInstant(InstantsInput input)
        {
            return Delete(_mapper.Map<Instants>(input));
        }

        #endregion
    }
}
