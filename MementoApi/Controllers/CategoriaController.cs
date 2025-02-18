using MementoApi.Utilitarios;
using MementoDominio.Comandos;
using MementoDominio.Comandos.Categoria;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
    public class CategoriaController : Controller
    {
        public CategoriaManipulador categoriaManipulador { get; set; }
        public CategoriaController(CategoriaManipulador categoriaManipulador)
        {
            this.categoriaManipulador = categoriaManipulador;
        }

        [HttpGet]
        public ActionResult<List<CategoriaListarComandoSaida>> Listar()
        {
            return categoriaManipulador.Listar(TokenUtilitario.RetornarIdUsuario(HttpContext));
        }

        [HttpPost]
        public ActionResult Incluir([FromBody] CategoriaCadastroComandoEntrada dados)
        {
            categoriaManipulador.Incluir(dados, TokenUtilitario.RetornarIdUsuario(HttpContext));
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] CategoriaCadastroComandoEntrada dados)
        {
            categoriaManipulador.Alterar(id, dados, TokenUtilitario.RetornarIdUsuario(HttpContext));
            return Ok();
        }
    }
}
