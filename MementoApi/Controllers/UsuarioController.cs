using MementoDominio.Comandos.Usuario;
using MementoDominio.Manipuladores;
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
        public ActionResult Incluir([FromBody] UsuarioCadastroComandoEntrada dados)
        {
            usuarioManipulador.Incluir(dados);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] UsuarioCadastroComandoEntrada dados)
        {
            usuarioManipulador.Alterar(id, dados);
            return Ok();
        }
    }
}
