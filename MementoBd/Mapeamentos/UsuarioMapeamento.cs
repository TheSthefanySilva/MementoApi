using MementoBd.Entidades;
using MementoBd.Mapeamentos.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MementoBd.Mapeamentos
{
    public class UsuarioMapeamento : PadraoMapeamento<UsuarioEntidade>
    {
        public UsuarioMapeamento() : base("Usuario")
        {
        }

        public override void IncluirConfiguracao(EntityTypeBuilder<UsuarioEntidade> builder)
        {
            builder.Property(x => x.Nome)
              .IsRequired()
              .HasColumnName("Nome")
              .HasColumnType("Varchar")
              .HasMaxLength(150);

            builder.Property(x => x.Email)
              .IsRequired()
              .HasColumnName("Email")
              .HasColumnType("Varchar")
              .HasMaxLength(200);

            builder.Property(x => x.Senha)
              .IsRequired()
              .HasColumnName("Senha")
              .HasColumnType("Varchar")
              .HasMaxLength(50);
        }
    }
}
