using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Templates
{
    public class TemplatesDto : BaseDto
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Template { get; set; }
        public int? TypeId { get; set; }
    }
}
