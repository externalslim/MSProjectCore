using Microsoft.AspNetCore.Mvc;
using MS.Application.Services.JobService;
using MS.Helper.Dtos.Jobs;

namespace MS.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class JobController : ControllerBase
    {
        private IJobService _jobService;
        public JobController(IJobService jobService)
        {
            _jobService = jobService;
        }

        [HttpGet]
        public JobsOutput GetAllJobs()
        {
            var output = new JobsOutput();
            output = _jobService.GetAllJobs();
            return output;
        }

        [HttpGet]
        public JobsOutput GetAllActiveJobs()
        {
            var output = new JobsOutput();
            output = _jobService.GetAllActiveJobs();
            return output;
        }

        [HttpGet]
        public JobsOutput GetAllJobsWithTypeQueryTemplate()
        {
            var output = new JobsOutput();
            output = _jobService.GetAllJobsWithTypeQueryTemplate();
            return output;
        }

        [HttpGet]
        public JobsOutput GetAllActiveJobsWithTypeQueryTemplate()
        {
            var output = new JobsOutput();
            output = _jobService.GetAllActiveJobsWithTypeQueryTemplate();
            return output;
        }

        [HttpPost]
        public JobsOutput GetAllJobsByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetAllJobsByTypeId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetAllActiveJobsByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetAllActiveJobsByTypeId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetAllJobsByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetAllJobsByTemplateId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetAllActiveJobsByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetAllActiveJobsByTemplateId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetAllJobsQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetAllJobsQueryId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetAllActiveJobsQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetAllActiveJobsQueryId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetJobsWithFilters(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetJobsWithFilters(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetJobById(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetJobById(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetJobByTypeId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetJobByTypeId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetJobByTemplateId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetJobByTypeId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput GetJobQueryId(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.GetJobQueryId(input);
            return output;
        }

        [HttpPost]
        public JobsOutput CreateJob(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.CreateJob(input);
            return output;
        }

        [HttpPost]
        public JobsOutput UpdateJob(JobsInput input)
        {
            var output = new JobsOutput();
            output = _jobService.UpdateJob(input);
            return output;
        }

        [HttpPost]
        public bool DeleteJob(JobsInput input)
        {
            return _jobService.DeleteJob(input);
        }
    }
}