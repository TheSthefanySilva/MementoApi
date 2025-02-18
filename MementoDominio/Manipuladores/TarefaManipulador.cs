using MementoBd;
using MementoBd.Entidades;
using MementoDominio.Comandos.Tarefa;
using MementoDominio.TratamentoDeErro;
using Microsoft.EntityFrameworkCore;

namespace MementoDominio.Manipuladores
{
    public class TarefaManipulador 
    {
        public ContextoBd contexto { get; set; }
        public TarefaManipulador(ContextoBd contextoBd)
        {
            this.contexto = contextoBd;
        }

        public List<TarefaListarComandoSaida> Listar(int idUsuario)
        {
            return contexto.Tarefa
                .Include(x => x.Lista)
                .Where(x => x.Lista.UsuarioId == idUsuario)
                .OrderBy(x => x.Prioridade)
                .Select(x => new TarefaListarComandoSaida()
                {
                    Id = x.Id,
                    Titulo = x.Titulo,
                    Descricao = x.Descricao,
                    Prioridade = x.Prioridade,
                    Status = x.Status,
                    DataLimite = x.DataLimite,
                    ListaId = x.ListaId,
                    CategoriaId = x.CategoriaId,
                    Inativo = x.Inativo,
                    DataCriacao = x.CriadoEm
                })
                .ToList();
        }

        public void Incluir(TarefaCadastroComandoEntrada dados)
        {
            var novoItem = new TarefaEntidade();
            PreencherItem(novoItem, dados);
            contexto.Add(novoItem);
            contexto.SaveChanges();
        }

        public void Alterar(int id, TarefaCadastroComandoEntrada dados)
        {
            var item = contexto.Tarefa.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new DominioExcecao("Tarefa não encontrada");

            PreencherItem(item, dados);
            contexto.SaveChanges();
        }

        private void PreencherItem(TarefaEntidade entidade, TarefaCadastroComandoEntrada dados)
        {
            entidade.Titulo = dados.Titulo;
            entidade.Descricao = dados.Descricao;
            entidade.Prioridade = dados.Prioridade;
            entidade.Status = dados.Status;
            entidade.DataLimite = dados.DataLimite;
            entidade.ListaId = dados.ListaId;
            entidade.CategoriaId = dados.CategoriaId;
            entidade.Inativo = dados.Inativo;
            
            if (entidade.Id > 0)
                entidade.AtualizadoEm = DateTime.Now;
            else
                entidade.CriadoEm = DateTime.Now;
        }
    }
}
