using AutoMapper;
using Sigma.Application.Dtos.Projeto;
using Sigma.Application.Interfaces;
using Sigma.Domain.Entities;
using Sigma.Domain.Enums;
using Sigma.Domain.Interfaces.Repositories;

namespace Sigma.Application.Services
{
    public class ProjetoService : IProjetoService
    {
        private readonly IMapper _mapper;
        private readonly IProjetoRepository _projetoRepository;
        private readonly IUsuarioRepository _usuarioRepository;

        public ProjetoService(IMapper mapper, IProjetoRepository projetoRepository, IUsuarioRepository usuarioRepository)
        {
            _mapper = mapper;
            _projetoRepository = projetoRepository;
            _usuarioRepository = usuarioRepository;

        }

        public async Task<RetornoProjetoNovoDto> Inserir(ProjetoNovoDto model, string loginUsuario)
        {
            var usuario = await _usuarioRepository.BuscarPorLogin(loginUsuario);

            var projeto = _mapper.Map<Projeto>(model);
            projeto.UsuarioId = usuario.Id;

            await _projetoRepository.Inserir(projeto);

            return _mapper.Map<RetornoProjetoNovoDto>(projeto);
        }

        public async Task<List<RetornoProjetoDto>> Buscar(string loginUsuario)
        {
            var projetos = await _projetoRepository.Buscar(loginUsuario);
            return _mapper.Map<List<RetornoProjetoDto>>(projetos);
        }

        public async Task<RetornoProjetoDto> BuscarPorNomeStatus(BuscaProjetoDto model, string usuario)
        {
            var projeto = await _projetoRepository.BuscarPorNomeStatus(model.Nome, model.Status, usuario);
            return _mapper.Map<RetornoProjetoDto>(projeto);
        }

        public async Task<bool> Atualizar(ProjetoDto model, string usuario)
        {
            var projeto = await _projetoRepository.BuscarPorId(model.Id, usuario);

            if (projeto == null)
                 return false;

            _mapper.Map(model, projeto);

            return await _projetoRepository.Atualizar(projeto);
        }

        public async Task<bool> Deletar(long id, string loginUsuario)
        {
            var projeto = await _projetoRepository.BuscarPorId(id, loginUsuario);

            if (projeto == null)
                return false;

            if (projeto.Status != StatusProjetoEnum.EmAnalise
                && projeto.Status != StatusProjetoEnum.AnaliseRealizada
                && projeto.Status != StatusProjetoEnum.AnaliseAprovada
                && projeto.Status != StatusProjetoEnum.Cancelado)
                return false;

            return await _projetoRepository.Deletar(projeto);
        }

  
    }
}
