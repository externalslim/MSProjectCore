using MS.Helper.Dtos.Base;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Dtos.Instants
{
    public class InstantsDto : BaseDto
    {
        public int? TypeId { get; set; }
        public int? TemplateId { get; set; }
        public int? QueryId { get; set; }
        public TemplatesDto TemplatesModel { get; set; }
        public QueriesDto QueriesModel { get; set; }
        public TypesDto TypesModel { get; set; }
    }
}
