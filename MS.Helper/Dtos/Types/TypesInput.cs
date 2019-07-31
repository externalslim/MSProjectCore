using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Types
{
    public class TypesInput : BaseInput
    {
        public int EnumId { get; set; }
        public string Name { get; set; }
    }
}
