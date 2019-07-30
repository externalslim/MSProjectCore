using AutoMapper;
using MS.Data.Models;
using MS.Helper.Dtos.Instants;
using MS.Helper.Dtos.LogStashes;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Schedules;
using MS.Helper.Dtos.TemplateQueries;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;
using System;
using System.Collections.Generic;
using System.Text;

namespace MS.Helper.Mapping
{
    public class MapperProfile : Profile
    {
        public MapperProfile()
        {
            CreateMap<Instants, InstantsDto>();
            CreateMap<InstantsInput, Instants>();
            CreateMap<InstantsDto, Instants>();

            CreateMap<LogStashes, LogStashesDto>();
            CreateMap<LogStashesInput, LogStashes>();
            CreateMap<LogStashesDto, LogStashes>();

            CreateMap<Queries, QueriesDto>();
            CreateMap<QueriesInput, Queries>();
            CreateMap<QueriesDto, Queries>();

            CreateMap<Schedules, SchedulesDto>();
            CreateMap<SchedulesInput, Schedules>();
            CreateMap<SchedulesDto, Schedules>();

            CreateMap<TemplateQueries, TemplateQueriesDto>();
            CreateMap<TemplateQueriesInput, TemplateQueries>();
            CreateMap<TemplateQueriesDto, TemplateQueries>();

            CreateMap<Templates, TemplatesDto>();
            CreateMap<TemplatesInput, Templates>();
            CreateMap<TemplatesDto, Templates>();

            CreateMap<Types, TypesDto>();
            CreateMap<TypesInput, Types>();
            CreateMap<TypesDto, Types>();
        }
    }
}
