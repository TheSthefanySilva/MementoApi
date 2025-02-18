using MementoApi.Utilitarios;
using MementoDominio.Comandos.Usuario;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UsuarioController : Controller
    {
        public UsuarioManipulador usuarioManipulador { get; set; }
        public UsuarioController(UsuarioManipulador usuarioManipulador)
        {
            this.usuarioManipulador = usuarioManipulador;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Incluir([FromBody] UsuarioCadastroComandoEntrada dados)
        {
            usuarioManipulador.Incluir(dados);
            return Ok();
        }

        [HttpPut("{id}")]
        [Authorize]
        public ActionResult Alterar(int id, [FromBody] UsuarioCadastroComandoEntrada dados)
        {
            usuarioManipulador.Alterar(id, dados);
            return Ok();
        }

        [HttpGet()]
        [Authorize]
        public ActionResult<UsuarioLogadoComandoSaida> ObterDadosUsuarioLogado()
        {
            return Ok(usuarioManipulador.Obter(TokenUtilitario.RetornarIdUsuario(HttpContext)));
        }
    }
}
