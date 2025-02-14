using MementoApi.Infra;
using Microsoft.EntityFrameworkCore.Design;

namespace MementoBd.Migrations.Configuracoes
{
    public class DbContextMigrationFactory : IDesignTimeDbContextFactory<ContextoBd>
    {
        public ContextoBd CreateDbContext(string[] args)
        {
            return new ContextoBd();
        }
    }
}
