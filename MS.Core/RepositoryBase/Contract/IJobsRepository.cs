using MS.Core.RepositoryBase.DependencyManager;
using MS.Data.Models;
using MS.Helper.Dtos.Jobs;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Core.RepositoryBase.Contract
{
    public interface IJobsRepository : IRepository<Jobs>, IRepositoryDependency
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
