using System;
using System.Collections.Generic;

namespace MS.Data.Models
{
    public partial class JobHistory
    {
        public int Id { get; set; }
        public int? JobId { get; set; }
        public int? Counter { get; set; }
        public int? MaxSend { get; set; }
        public int? TotalSend { get; set; }
    }
}
