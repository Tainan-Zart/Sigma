using AutoMapper;
using Sigma.Application.Dtos.Usuario;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.CrossCutting.Helpers;

namespace Sigma.Application.Services
{
    public class UsuarioService : IUsuarioService
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IMapper _mapper;

        public UsuarioService(IUsuarioRepository clienteRepository, IMapper mapper)
        {
            _usuarioRepository = clienteRepository;
            _mapper = mapper;
        }


        public async Task<Usuario> BuscarPorLogin(string login)
        {
            return await _usuarioRepository.BuscarPorLogin(login);
        }

        public async Task<bool> Cadastrar(UsuarioDto usuarioDto)
        {
            var usuario = _mapper.Map<Usuario>(usuarioDto);
            return await _usuarioRepository.Inserir(usuario);
        }

        public async Task<bool> VerificarLogin(string login)
        {
            var cliente = await BuscarPorLogin(login);
            return cliente != null;
        }

        public async Task<bool> VerificarLoginSenha(string login, string senha)
        {
            var cliente = await BuscarPorLogin(login);

            if (cliente == null)
                return false;

            var senhaCorreta = StringHelper.VerificarHash(senha, cliente.Senha);

            if (senhaCorreta)
                return true;
            else
                return false;
        }
    }
}
