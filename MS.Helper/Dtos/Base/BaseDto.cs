using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Base
{
    public class BaseDto
    {
        public int Id { get; set; }
        public bool? IsDeleted { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
        public int? UpdatedBy { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
