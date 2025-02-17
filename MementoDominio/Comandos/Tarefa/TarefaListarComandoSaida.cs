using MementoDominio.Comandos.Contrato;

namespace MementoDominio.Comandos.Tarefa
{
    public class TarefaListarComandoSaida : ContratoListarComandoSaida
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public string Status { get; set; }
        public DateTime DataLimite { get; set; }
        public int ListaId { get; set; }
        public int CategoriaId { get; set; }
    }
}
