using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.JobHistory
{
    public class JobHistoryInput
    {
        public int Id { get; set; }
        public int JobId { get; set; }
        public int Counter { get; set; }
        public int MaxSend { get; set; }
        public int TotalSend { get; set; }
    }
}
