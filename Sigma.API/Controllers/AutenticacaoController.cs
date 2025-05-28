using Microsoft.AspNetCore.Mvc;
using Sigma.Application.Dtos.Login;
using Sigma.Application.Interfaces;

namespace Sigma.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AutenticacaoController : Controller
    {
        private readonly IAutenticacaoService _autenticacaoService;

        public AutenticacaoController(IAutenticacaoService autenticacaoService)
        {
            _autenticacaoService = autenticacaoService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginDto dto)
        {
            var usuarioValido = await _autenticacaoService.VerificarUsuario(dto);

            if(!usuarioValido)
                return Unauthorized($"Login ou Senha Incorretos!");

            var token = await _autenticacaoService.GerarToken(dto);

            return new JsonResult(token);
        }
    }
}
