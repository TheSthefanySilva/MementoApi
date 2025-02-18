using MementoApi.Utilitarios;
using MementoDominio.Comandos.Tarefa;
using MementoDominio.Manipuladores;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace MementoApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    [Authorize]
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
            return tarefaManipulador.Listar(TokenUtilitario.RetornarIdUsuario(HttpContext));
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
