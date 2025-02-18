

using MementoBd;
using MementoBd.Entidades;
using MementoDominio.Comandos.Usuario;
using MementoDominio.TratamentoDeErro;

namespace MementoDominio.Manipuladores
{
    public class UsuarioManipulador
    {
        public ContextoBd contexto { get; set; }
        public UsuarioManipulador(ContextoBd contextoBd)
        {
            this.contexto = contextoBd;
        }

        public UsuarioLogadoComandoSaida Obter(int idUsuario)
        {
            var item = contexto.Usuario.FirstOrDefault(x => x.Id == idUsuario);
            if (item == null)
                throw new DominioExcecao("Usuário não encontrado");

            return new UsuarioLogadoComandoSaida()
            {
                Id = item.Id,
                Nome = item.Nome,
                Email = item.Email,
                Senha = item.Senha,
                Inativo = item.Inativo,
                DataCriacao = item.CriadoEm,
            };
        }

        public void Incluir(UsuarioCadastroComandoEntrada dados)
        {
            var novoItem = new UsuarioEntidade();
            PreencherItem(novoItem, dados);
            contexto.Add(novoItem);
            contexto.SaveChanges();
        }

        public void Alterar(int id, UsuarioCadastroComandoEntrada dados)
        {
            contexto.TestarConexao();
            contexto.ExecutarMigracao();

            var item = contexto.Usuario.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new DominioExcecao("Usuário não encontrado");

            PreencherItem(item, dados);
            contexto.SaveChanges();
        }

        private void PreencherItem(UsuarioEntidade entidade, UsuarioCadastroComandoEntrada dados)
        {
            entidade.Nome = dados.Nome;
            entidade.Email = dados.Email;
            entidade.Senha = dados.Senha;
            entidade.Inativo = dados.Inativo;
            
            if (entidade.Id > 0)
                entidade.AtualizadoEm = DateTime.Now;
            else
                entidade.CriadoEm = DateTime.Now;
        }
    }
}
