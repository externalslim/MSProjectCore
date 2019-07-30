using System;
using System.Collections.Generic;

namespace MS.Data.Models
{
    public partial class LogStashes
    {
        public int Id { get; set; }
        public string Info { get; set; }
        public string Exception { get; set; }
        public string Method { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
