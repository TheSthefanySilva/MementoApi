

using MementoBd;
using MementoBd.Entidades;
using MementoDominio.Comandos.Lista;
using MementoDominio.TratamentoDeErro;

namespace MementoDominio.Manipuladores
{
    public class ListaManipulador 
    {
        public ContextoBd contexto { get; set; }
        public ListaManipulador(ContextoBd contextoBd)
        {
            this.contexto = contextoBd;
        }

        public List<ListaListarComandoSaida> Listar(int idUsuario)
        {
            return contexto.Lista
                .Where(x => x.UsuarioId == idUsuario)
                .Select(x => new ListaListarComandoSaida()
                {
                    Id = x.Id,
                    Nome = x.Nome,
                    Descricao = x.Descricao,
                    Inativo = x.Inativo,
                    DataCriacao = x.CriadoEm
                })
                .ToList();
        }

        public void Incluir(ListaCadastroComandoEntrada dados, int idUsuario)
        {
            var novoItem = new ListaEntidade();
            PreencherItem(novoItem, dados, idUsuario);
            contexto.Add(novoItem);
            contexto.SaveChanges();
        }

        public void Alterar(int id, ListaCadastroComandoEntrada dados, int idUsuario)
        {
            var item = contexto.Lista.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new DominioExcecao("Categoria não encontrada");

            PreencherItem(item, dados, idUsuario);
            contexto.SaveChanges();
        }

        private void PreencherItem(ListaEntidade entidade, ListaCadastroComandoEntrada dados, int idUsuario)
        {
            entidade.Nome = dados.Nome;
            entidade.Descricao = dados.Descricao;
            entidade.Inativo = dados.Inativo;
            entidade.UsuarioId = idUsuario;
            
            if (entidade.Id > 0)
                entidade.AtualizadoEm = DateTime.Now;
            else
                entidade.CriadoEm = DateTime.Now;
        }
    }
}
