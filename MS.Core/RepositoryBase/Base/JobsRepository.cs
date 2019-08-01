using AutoMapper;
using MS.Core.RepositoryBase.Contract;
using MS.Data.Models;
using MS.Helper.Dtos.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Base
{
    public class JobsRepository : Repository<Jobs>, IJobsRepository
    {
        private IMapper _mapper;
        public JobsRepository(IMapper mapper)
        {
            _mapper = mapper;
        }

        #region Get List
        public JobsOutput GetAllJobs()
        {
            var output = new JobsOutput();
            var jobs = GetAll();
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }

        public JobsOutput GetAllActiveJobs()
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => !x.IsDeleted);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }

        public JobsOutput GetAllJobsByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => x.TemplateId == input.TemplateId);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }
        public JobsOutput GetAllActiveJobsByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => x.TemplateId == input.TemplateId && !x.IsDeleted);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }

        public JobsOutput GetAllJobsByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => x.TypeId == input.TypeId);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }
        public JobsOutput GetAllActiveJobsByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => x.TypeId == input.TypeId && !x.IsDeleted);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }

        public JobsOutput GetAllJobsQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => x.QueryId == input.QueryId);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }
        public JobsOutput GetAllActiveJobsQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            var jobs = GetAllWithFilter(x => x.QueryId == input.QueryId && !x.IsDeleted);
            if (jobs.Count > 0)
            {
                output.JobsListModel = _mapper.Map<List<JobsDto>>(jobs);
            }
            return output;
        }
        #endregion

        #region Get ById
        public JobsOutput GetJobById(JobsInput input)
        {
            var output = new JobsOutput();
            var job = GetWithFilter(x => x.Id == input.Id);
            if (job != null)
            {
                output.JobsModel = _mapper.Map<JobsDto>(job);
            }
            return output;
        }

        public JobsOutput GetJobByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            var job = GetWithFilter(x => x.TemplateId == input.TemplateId);
            if (job != null)
            {
                output.JobsModel = _mapper.Map<JobsDto>(job);
            }
            return output;
        }

        public JobsOutput GetJobByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            var job = GetWithFilter(x => x.TypeId == input.TypeId);
            if (job != null)
            {
                output.JobsModel = _mapper.Map<JobsDto>(job);
            }
            return output;
        }

        public JobsOutput GetJobQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            var job = GetWithFilter(x => x.QueryId == input.QueryId);
            if (job != null)
            {
                output.JobsModel = _mapper.Map<JobsDto>(job);
            }
            return output;
        }
        #endregion

        #region Create Update Delete
        public JobsOutput CreateJob(JobsInput input)
        {
            var output = new JobsOutput();
            var job = Create(_mapper.Map<Jobs>(input));
            if (job != null)
            {
                output.JobsModel = _mapper.Map<JobsDto>(job);
            }
            return output;
        }
        public JobsOutput UpdateJob(JobsInput input)
        {
            var output = new JobsOutput();
            Update(_mapper.Map<Jobs>(input));
            var job = GetWithFilter(x => x.Id == input.Id);
            if (job != null)
            {
                output.JobsModel = _mapper.Map<JobsDto>(job);
            }
            return output;
        }

        public bool DeleteJob(JobsInput input)
        {
            return Delete(_mapper.Map<Jobs>(input));
        }
        #endregion

    }
}
