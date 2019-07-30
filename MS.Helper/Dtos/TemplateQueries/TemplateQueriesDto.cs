using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.TemplateQueries
{
    public class TemplateQueriesDto : BaseDto
    {
        public int? TemplateId { get; set; }
        public int? QueryId { get; set; }
        public int? TypeId { get; set; }
        public int? ScheduleId { get; set; }
    }
}
