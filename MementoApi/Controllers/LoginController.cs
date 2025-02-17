using MementoDominio.Comandos.Login;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class LoginController : Controller
    {
        public LoginManipulador loginManipulador { get; set; }
        public LoginController(LoginManipulador loginManipulador)
        {
            this.loginManipulador = loginManipulador;
        }

        [HttpPost]
        public ActionResult<LoginComandoSaida> RealizarLogin([FromBody] LoginComandoEntrada dados)
        {
            return Ok(loginManipulador.RealizarLogin(dados));   
        }

    }
}
