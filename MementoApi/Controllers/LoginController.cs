using MementoDominio.Comandos.Login;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [AllowAnonymous]
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
