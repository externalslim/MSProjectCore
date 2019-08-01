using MS.Application.DependencyManager;
using MS.Helper.Dtos.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Application.Services.JobService
{
    public interface IJobService : IServiceDependency
    {
        #region Get List
        JobsOutput GetAllJobs();
        JobsOutput GetAllActiveJobs();

        JobsOutput GetAllJobsByTypeId(JobsInput input);
        JobsOutput GetAllActiveJobsByTypeId(JobsInput input);

        JobsOutput GetAllJobsByTemplateId(JobsInput input);
        JobsOutput GetAllActiveJobsByTemplateId(JobsInput input);

        JobsOutput GetAllJobsQueryId(JobsInput input);
        JobsOutput GetAllActiveJobsQueryId(JobsInput input);

        JobsOutput GetAllJobsWithTypeQueryTemplate();
        JobsOutput GetAllActiveJobsWithTypeQueryTemplate();

        JobsOutput GetJobsWithFilters(JobsInput input);
        #endregion

        #region Get ById
        JobsOutput GetJobById(JobsInput input);
        JobsOutput GetJobByTypeId(JobsInput input);
        JobsOutput GetJobByTemplateId(JobsInput input);
        JobsOutput GetJobQueryId(JobsInput input);
        #endregion

        #region Create, Update, Delete
        JobsOutput CreateJob(JobsInput input);
        JobsOutput UpdateJob(JobsInput input);
        bool DeleteJob(JobsInput input);
        #endregion
    }
}
