using AutoMapper;
using Sigma.Application.Dtos.Usuario;
using Sigma.Domain.Entities;
using Sigma.Infra.CrossCutting.Helpers;

namespace Sigma.Application.Mappers.UsuarioMappers
{
    public class UsuarioMapper : Profile
    {
        public UsuarioMapper()
        {
            CreateMap<UsuarioDto, Usuario>()
                .ForMember(dest => dest.Senha, opt => opt.MapFrom(src => StringHelper.GerarHash(src.Senha)));

        }
    }
}
