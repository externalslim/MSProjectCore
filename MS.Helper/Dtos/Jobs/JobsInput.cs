using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Jobs
{
    public class JobsInput : BaseInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? TemplateId { get; set; }
        public int? QueryId { get; set; }
        public int? TypeId { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int? Every { get; set; }
        public int? WhenSet { get; set; }
    }
}
