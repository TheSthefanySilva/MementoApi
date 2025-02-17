using MementoDominio.Comandos.Lista;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ListaController : Controller
    {
        public ListaManipulador listaManipulador { get; set; }
        public ListaController(ListaManipulador listaManipulador)
        {
            this.listaManipulador = listaManipulador;
        }

        [HttpGet]
        public ActionResult<List<ListaListarComandoSaida>> Listar()
        {
            return listaManipulador.Listar();
        }

        [HttpPost]
        public ActionResult Incluir([FromBody] ListaCadastroComandoEntrada dados)
        {
            listaManipulador.Incluir(dados);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] ListaCadastroComandoEntrada dados)
        {
            listaManipulador.Alterar(id, dados);
            return Ok();
        }
    }
}
