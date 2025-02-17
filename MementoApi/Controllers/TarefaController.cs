using MementoDominio.Comandos.Tarefa;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class TarefaController : Controller
    {
        public TarefaManipulador tarefaManipulador { get; set; }
        public TarefaController(TarefaManipulador tarefaManipulador)
        {
            this.tarefaManipulador = tarefaManipulador;
        }

        [HttpGet]
        public ActionResult<List<TarefaListarComandoSaida>> Listar()
        {
            return tarefaManipulador.Listar();
        }

        [HttpPost]
        public ActionResult Incluir([FromBody] TarefaCadastroComandoEntrada dados)
        {
            tarefaManipulador.Incluir(dados);
            return Ok();
        }

        [HttpPut("{id}")]
        public ActionResult Alterar(int id, [FromBody] TarefaCadastroComandoEntrada dados)
        {
            tarefaManipulador.Alterar(id, dados);
            return Ok();
        }
    }
}
