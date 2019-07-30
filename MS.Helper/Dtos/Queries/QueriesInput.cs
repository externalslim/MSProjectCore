using MS.Helper.Dtos.Base;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Queries
{
    public class QueriesInput : BaseInput
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string Query { get; set; }
        public int? TypeId { get; set; }
    }
}
