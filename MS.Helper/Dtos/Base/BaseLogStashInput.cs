using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Base
{
    public class BaseLogStashInput
    {
        public int Id { get; set; }
        public int? CreatedBy { get; set; }
        public DateTime? CreatedDate { get; set; }
    }
}
