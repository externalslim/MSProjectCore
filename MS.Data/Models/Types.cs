using System;
using System.Collections.Generic;

namespace MS.Data.Models
{
    public partial class Types
    {
        public int Id { get; set; }
        public int? EnumId { get; set; }
        public string Name { get; set; }
        public bool IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
