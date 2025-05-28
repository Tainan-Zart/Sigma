using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos.Projeto;
using Sigma.Application.Interfaces;
using Sigma.Domain.Enums;

namespace Sigma.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ProjetoController : ControllerBase
    {
        private readonly IProjetoService _projetoService;

        public ProjetoController(IProjetoService projetoService)
        {
            _projetoService = projetoService;
        }

        [HttpPost]
        public async Task<IActionResult> Inserir([FromBody] ProjetoNovoDto model)
        {
            var loginUsuario = User.Identity.Name;
            return new JsonResult(await _projetoService.Inserir(model, loginUsuario));
        }

        [HttpGet]
        public async Task<IActionResult> Buscar()
        {
            var loginUsuario = User.Identity.Name;
            return new JsonResult(await _projetoService.Buscar(loginUsuario));
        }

        [HttpGet("buscar")]
        public async Task<IActionResult> BuscarPorNomeStatus([FromQuery] BuscaProjetoDto model)
        {
            var loginUsuario = User.Identity.Name;
            return new JsonResult(await _projetoService.BuscarPorNomeStatus(model, loginUsuario));
        }

        [HttpPut]
        public async Task<IActionResult> Atualizar([FromBody] ProjetoDto model)
        {
            var loginUsuario = User.Identity.Name;

            await _projetoService.Atualizar(model, loginUsuario);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Deletar(int id)
        {
            var loginUsuario = User.Identity.Name;

            var projetoDeletado = await _projetoService.Deletar(id, loginUsuario);

            if (!projetoDeletado)
                return BadRequest("Não é possivel deletar esse projeto!");

            return NoContent();
        }
    }
}
