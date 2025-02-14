using System.ComponentModel.DataAnnotations.Schema;

namespace MementoBd.Entidades
{
    public class TarefaEntidade : EntidadeBase
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public string Status { get; set; }
        public DateTime DataLimite { get; set; }
        public int ListaId { get; set; }
        public int CategoriaId { get; set; }
        public ListaEntidade Lista { get; set; }
        public CategoriaEntidade Categoria { get; set; }
    }
}
