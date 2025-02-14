using MementoBd.Entidades;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MementoBd.Mapeamentos.Contrato
{
    public abstract class PadraoMapeamento<TEntidade> : IEntityTypeConfiguration<TEntidade> where TEntidade : EntidadeBase
    {
        private readonly string _tabela;
        protected PadraoMapeamento(string tabela)
        {
            _tabela = tabela;
        }

        public void Configure(EntityTypeBuilder<TEntidade> builder)
        {
            builder.ToTable(_tabela);
            builder.HasKey(prop => prop.Id);

            builder
            .Property(prop => prop.Id)
                .ValueGeneratedOnAdd()
                .UseIdentityColumn()
                .HasColumnName("Id")
                .HasColumnType("int");

            builder.Property(x => x.CriadoEm)
              .HasColumnName("CriadoEm")
              .HasColumnType("Datetime");

            builder.Property(x => x.AtualizadoEm)
              .HasColumnName("AtualizadoEm")
              .HasColumnType("Datetime");

            builder.Property(x => x.Inativo)
              .HasColumnName("Inativo")
              .HasColumnType("bit");

            IncluirConfiguracao(builder);
        }

        public abstract void IncluirConfiguracao(EntityTypeBuilder<TEntidade> builder);
    }
}
