using System;
using System.Collections.Generic;

namespace MS.Data.Models
{
    public partial class TemplateQueries
    {
        public int Id { get; set; }
        public int? TemplateId { get; set; }
        public int? QueryId { get; set; }
        public int? TypeId { get; set; }
        public int? ScheduleId { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
