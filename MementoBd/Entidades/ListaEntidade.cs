using System.ComponentModel.DataAnnotations.Schema;

namespace MementoBd.Entidades
{
    public class ListaEntidade : EntidadeBase
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
        public int UsuarioId { get; set; }
        public UsuarioEntidade Usuario { get; set; }
        public virtual List<TarefaEntidade> Tarefas { get; set; }
    }
}
