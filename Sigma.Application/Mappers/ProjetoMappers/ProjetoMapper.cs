using AutoMapper;
using Sigma.Application.Dtos.Projeto;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;

namespace Sigma.Application.Mappers.ProjetoMappers
{
    public class ProjetoMapper : Profile
    {
        public ProjetoMapper()
        {
            CreateMap<ProjetoNovoDto, Projeto>()
                .ForMember(dest => dest.Status, opt => opt.MapFrom(src => StatusProjetoEnum.EmAnalise))
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Projeto, RetornoProjetoNovoDto>();

            CreateMap<ProjetoDto, Projeto>()
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => DateTime.UtcNow));

            CreateMap<Projeto, RetornoProjetoDto>()
                .ForMember(dest => dest.DataInicio, opt => opt.MapFrom(src => src.DataInicio.ToString("dd/MM/yyyy")));

        }
    }
}


