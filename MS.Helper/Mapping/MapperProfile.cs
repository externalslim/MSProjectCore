using AutoMapper;
using MS.Data.Models;
using MS.Helper.Dtos.Instants;
using MS.Helper.Dtos.Jobs;
using MS.Helper.Dtos.LogStashes;
using MS.Helper.Dtos.Queries;
using MS.Helper.Dtos.Templates;
using MS.Helper.Dtos.Types;

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
            CreateMap<QueriesOutput, QueriesDto>();

            CreateMap<Jobs, JobsDto>();
            CreateMap<JobsInput, Jobs>();
            CreateMap<JobsDto, Jobs>();

            CreateMap<Templates, TemplatesDto>();
            CreateMap<TemplatesInput, Templates>();
            CreateMap<TemplatesDto, Templates>();
            CreateMap<TemplatesOutput, TemplatesDto>();

            CreateMap<Types, TypesDto>();
            CreateMap<TypesInput, Types>();
            CreateMap<TypesDto, Types>();
            CreateMap<TypesOutput, TypesDto>();
        }
    }
}
