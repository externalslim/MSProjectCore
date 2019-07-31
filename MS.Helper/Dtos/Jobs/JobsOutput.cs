using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Jobs
{
    public class JobsOutput
    {
        public List<JobsDto> JobsListModel { get; set; }
        public JobsDto JobsModel { get; set; }
    }
}
