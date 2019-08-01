using AutoMapper;
using MS.Application.DependencyManager;
using MS.Core.RepositoryBase.Contract;
using MS.Data.Models;
using MS.Helper.Dtos.Jobs;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MS.Application.Services.JobService
{
    public class JobService : IJobService, IServiceDependency
    {
        private IJobsRepository _jobsRepository;
        private ITemplatesRepository _templatesRepository;
        private ITypesRepository _typesRepository;
        private IQueriesRepository _queriesRepository;
        private IMapper _mapper;

        public JobService(
            IJobsRepository jobsRepository,
            ITemplatesRepository templatesRepository,
            ITypesRepository typesRepository,
            IQueriesRepository queriesRepository,
            IMapper mapper
            )
        {
            _jobsRepository = jobsRepository;
            _templatesRepository = templatesRepository;
            _typesRepository = typesRepository;
            _queriesRepository = queriesRepository;
            _mapper = mapper;
        }


        #region GetList
        public JobsOutput GetAllJobs()
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllJobs();
            return output;
        }
        public JobsOutput GetAllActiveJobs()
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllActiveJobs();
            return output;
        }

        public JobsOutput GetAllJobsByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllJobsByTemplateId(input);
            return output;
        }
        public JobsOutput GetAllActiveJobsByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllActiveJobsByTemplateId(input);
            return output;
        }

        public JobsOutput GetAllJobsByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllJobsByTypeId(input);
            return output;
        }
        public JobsOutput GetAllActiveJobsByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllActiveJobsByTypeId(input);
            return output;
        }

        public JobsOutput GetAllJobsQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllJobsQueryId(input);
            return output;
        }
        public JobsOutput GetAllActiveJobsQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetAllActiveJobsQueryId(input);
            return output;
        }


        public JobsOutput GetAllActiveJobsWithTypeQueryTemplate()
        {
            var output = new JobsOutput();

            var jobs = _jobsRepository.GetAllActiveJobs();
            if (jobs.JobsListModel.Count > 0)
            {
                output = Navigator(output);
            }

            return output;
        }

        public JobsOutput GetAllJobsWithTypeQueryTemplate()
        {

            var output = new JobsOutput();
            output = _jobsRepository.GetAllJobs();
            if (output.JobsListModel.Count > 0)
            {
                output = Navigator(output);
            }

            return output;
        }
        #endregion


        #region Get ById
        public JobsOutput GetJobById(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetJobById(input);
            output = Navigator(output);
            return output;
        }

        public JobsOutput GetJobByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetJobByTemplateId(input);
            return output;
        }

        public JobsOutput GetJobByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetJobByTypeId(input);
            return output;
        }

        public JobsOutput GetJobQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.GetJobQueryId(input);
            return output;
        }

        public JobsOutput GetJobsWithFilters(JobsInput input)
        {
            var output = new JobsOutput();
            output = FilteredJobs(input);
            output = Navigator(output);
            return output;
        }
        #endregion


        #region Create, Update, Delete
        public JobsOutput CreateJob(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.CreateJob(input);
            return output;
        }
        public JobsOutput UpdateJob(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobsRepository.UpdateJob(input);
            return output;
        }
        public bool DeleteJob(JobsInput input)
        {
            return _jobsRepository.DeleteJob(input);
        }
        #endregion


        #region Extends
        private JobsOutput FilteredJobs(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = _jobsRepository.GetAllJobs();

            if (input.Id > 0)
            {
                jobs = GetJobById(input);
            }
            else
            {
                if (input.TemplateId != null && input.TemplateId > 0)
                {
                    jobs.JobsListModel = jobs.JobsListModel.Where(x => x.TemplateId == input.TemplateId).ToList();
                }
                if (input.QueryId != null && input.QueryId > 0)
                {
                    jobs.JobsListModel = jobs.JobsListModel.Where(x => x.QueryId == input.QueryId).ToList();
                }
                if (input.TypeId != null && input.TypeId > 0)
                {
                    jobs.JobsListModel = jobs.JobsListModel.Where(x => x.TypeId == input.TypeId).ToList();
                }
            }
            output = jobs;

            return output;
        }

        private JobsOutput Navigator(JobsOutput input)
        {
            var output = input;

            if (output.JobsListModel != null && output.JobsListModel.Count > 0)
            {
                //templates
                var templateIdList = output.JobsListModel.Select(x => x.TemplateId);
                var templates = _templatesRepository.GetAll();

                var filteredTemplates = new List<Templates>();
                if (templateIdList.Count() > 0 && templates.Count > 0)
                {
                    filteredTemplates = templates.Where(x => templateIdList.Contains(x.Id)).ToList();
                }
                //templates

                //queries
                var queryIdList = output.JobsListModel.Select(x => x.QueryId);
                var queries = _queriesRepository.GetAll();

                var filteredQueries = new List<Queries>();
                if (queryIdList.Count() > 0 && queries.Count > 0)
                {
                    filteredQueries = queries.Where(x => queryIdList.Contains(x.Id)).ToList();
                }
                //queries

                //types
                var typeIdList = output.JobsListModel.Select(x => x.TypeId);
                var types = _typesRepository.GetAll();

                var filteredTypes = new List<Types>();
                if (typeIdList.Count() > 0 && types.Count > 0)
                {
                    filteredTypes = types.Where(x => typeIdList.Contains(x.Id)).ToList();
                }
                //types

                foreach (var job in output.JobsListModel)
                {

                    var selectedTemplate = filteredTemplates.Where(x => x.Id == job.TemplateId).SingleOrDefault();
                    job.TemplatesModel = selectedTemplate != null ? _mapper.Map<TemplatesDto>(selectedTemplate) : null;

                    var selectedQuery = filteredQueries.Where(x => x.Id == job.QueryId).SingleOrDefault();
                    job.QueriesModel = selectedQuery != null ? _mapper.Map<QueriesDto>(selectedQuery) : null;

                    var selectedType = filteredTypes.Where(x => x.Id == job.TypeId).SingleOrDefault();
                    job.TypesModel = selectedType != null ? _mapper.Map<TypesDto>(selectedType) : null;
                }
            }
            else
            {
                //template
                var templateInput = new TemplatesInput();
                var templateId = output.JobsModel.TemplateId;
                templateInput.Id = templateId.Value;
                var template = _templatesRepository.GetTemplateById(templateInput);
                output.JobsModel.TemplatesModel = _mapper.Map<TemplatesDto>(template.TemplatesModel);
                //template

                //query
                var queryInput = new QueriesInput();
                var queryId = output.JobsModel.QueryId;
                queryInput.Id = queryId.Value;
                var query = _queriesRepository.GetQueryById(queryInput);
                output.JobsModel.QueriesModel = _mapper.Map<QueriesDto>(query.QueriesModel);
                //query

                //type
                var typeInput = new TypesInput();
                var typeId = output.JobsModel.QueryId;
                typeInput.Id = typeId.Value;
                var type = _typesRepository.GetTypeById(typeInput);
                output.JobsModel.TypesModel = _mapper.Map<TypesDto>(type.TypesModel);
                //type

            }

            return output;
        }

        #endregion
    }
}
