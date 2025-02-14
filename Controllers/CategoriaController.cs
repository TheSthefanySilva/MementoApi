using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class CategoriaController : Controller
    {
        // GET: CategoriaController
        [HttpGet]
        public ActionResult<List<string>> ListarCategorias()
        {
            
            var categoriaManipulador = new CategoriaManipulador();
            return categoriaManipulador.ListarCategorias();
        }

    }
}
