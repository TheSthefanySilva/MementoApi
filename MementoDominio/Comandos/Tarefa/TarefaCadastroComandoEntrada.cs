using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MementoDominio.Comandos.Tarefa
{
    public class TarefaCadastroComandoEntrada
    {
        public string Titulo { get; set; }
        public string Descricao { get; set; }
        public int Prioridade { get; set; }
        public string Status { get; set; }
        public DateTime DataLimite { get; set; }
        public int ListaId { get; set; }
        public int CategoriaId { get; set; }
        public bool Inativo { get; set; }
    }
}
