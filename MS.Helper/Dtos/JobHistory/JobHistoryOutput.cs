using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.JobHistory
{
    public class JobHistoryOutput
    {
        public List<JobHistoryDto> JobHistoryListModel { get; set; }
        public JobHistoryDto JobHistoryModel { get; set; }
    }
}
