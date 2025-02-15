using Microsoft.EntityFrameworkCore.Design;
using Microsoft.Extensions.Configuration;

namespace MementoBd.Migrations.Configuracoes
{
    public class DbContextMigrationFactory : IDesignTimeDbContextFactory<ContextoBd>
    {
        private readonly IConfiguration configuration;
        public DbContextMigrationFactory(IConfiguration configuration)
        {
            this.configuration = configuration;
        }

        public ContextoBd CreateDbContext(string[] args)
        {
            return new ContextoBd();
        }
    }
}
