using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.LogStashes
{
    public class LogStashesDto : BaseLogStashDto
    {
        public string Info { get; set; }
        public string Exception { get; set; }
        public string Method { get; set; }
    }
}
