using MementoDominio.Comandos;
using MementoDominio.Comandos.Categoria;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
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
            return categoriaManipulador.Listar();
        }

        [HttpPost]
        public ActionResult Incluir([FromBody] CategoriaCadastroComandoEntrada dados)
        {
            categoriaManipulador.Incluir(dados);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] CategoriaCadastroComandoEntrada dados)
        {
            categoriaManipulador.Alterar(id, dados);
            return Ok();
        }
    }
}
