using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos.Usuario;
using Sigma.Application.Interfaces;

namespace Sigma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }

        [HttpPost]
        public async Task<IActionResult> Cadastro([FromBody] UsuarioDto usuarioDto)
        {

            var usuarioCadastro = await _usuarioService.VerificarLogin(usuarioDto.Login);

            if (usuarioCadastro == true)
                return BadRequest("Login já cadastrado!");

            var usuario = await _usuarioService.Cadastrar(usuarioDto);

            if (usuario == false)
                return BadRequest("Erro ao cadastrar cliente!");

            return Ok("Usuário Cadastrado com sucesso!");
        }
    }
}
