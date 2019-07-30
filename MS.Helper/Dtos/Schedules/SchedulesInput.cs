using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Schedules
{
    public class SchedulesInput : BaseInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? Period { get; set; }
        public int? TimeType { get; set; }
        public DateTime? StartDate { get; set; }
        public DateTime? EndDate { get; set; }
    }
}
