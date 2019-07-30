using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Instants
{
    public class InstantsInput : BaseInput
    {
        public int? TypeId { get; set; }
        public int? TemplateId { get; set; }
        public int? QueryId { get; set; }
    }
}
