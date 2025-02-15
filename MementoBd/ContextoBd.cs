
using MementoApi.Infra.TratamentoDeErro;
using MementoBd.Mapeamentos;
using MementoBd.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

namespace MementoBd
{

    /*1. Cadastro de Usuário
O usuário deve ser capaz de criar uma conta com e-mail e senha.
O sistema deve validar e-mails e senhas.
2. Autenticação
O usuário deve conseguir fazer login com suas credenciais.
3. Gerenciamento de Tarefas
O usuário pode criar novas tarefas.
O usuário pode editar tarefas existentes.
O usuário pode marcar tarefas como concluídas.
O usuário pode excluir tarefas.
O usuário pode definir prazos para as tarefas.
4. Organização de Tarefas
O usuário pode categorizar tarefas em listas (ex: trabalho, pessoal).
O usuário pode atribuir prioridades às tarefas (alta, média, baixa).
O usuário pode favoritar uma tarefa.
5. Visualização de Tarefas
O usuário deve visualizar todas as suas tarefas em suas respectivas listas.
O sistema deve permitir a filtragem de tarefas por status (pendente, concluída) e por data de vencimento.
*/
    public class ContextoBd : DbContext
    {
        private readonly string _connectionString;

        #region Tabelas
        public DbSet<TarefaEntidade> Tarefa { get; set; }
        public DbSet<UsuarioEntidade> Usuario { get; set; }
        public DbSet<ListaEntidade> Lista { get; set; }
        public DbSet<CategoriaEntidade> Categoria { get; set; }
        #endregion

        public ContextoBd()
        {
            //var teste = configuracao.GetConnectionString("MementoBdStringConnection");
            _connectionString = "SERVER=localhost\\SQLEXPRESS;UID=memento_user;PWD=123@abc;DATABASE=MementoBd";
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(_connectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(UsuarioMapeamento).Assembly);
            
        }

        public void TestarConexao()
        {
            try
            {
                this.Database.OpenConnection();
                this.Database.CloseConnection();
            }
            catch (Exception ex)
            {
                throw new ContextoExcecao("Erro ao conectar com o banco de dados: " + ex.Message
                    + "\n. Inner Ex: "+ ex?.InnerException?.Message);
            }
        }

        public void ExecutarMigracao()
        {
            Database.Migrate();
        }
    }
}
