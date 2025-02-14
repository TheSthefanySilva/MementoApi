using MementoBd.Entidades;
using MementoBd.Mapeamentos.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MementoBd.Mapeamentos
{
    public class ListaMapeamento : PadraoMapeamento<ListaEntidade>
    {
        public ListaMapeamento() : base("Lista")
        {
        }

        public override void IncluirConfiguracao(EntityTypeBuilder<ListaEntidade> builder)
        {
            builder.Property(x => x.Nome)
              .IsRequired()
              .HasColumnName("Nome")
              .HasColumnType("Varchar")
              .HasMaxLength(150);

            builder.Property(x => x.Descricao)
              .IsRequired()
              .HasColumnName("Descricao")
              .HasColumnType("Varchar")
              .HasMaxLength(500);

            builder.Property(x => x.UsuarioId)
              .IsRequired()
              .HasColumnName("UsuarioId")
              .HasColumnType("Int");

            builder.HasOne(x => x.Usuario)
               .WithMany(tabelaPrincipal => tabelaPrincipal.Listas)
               .HasForeignKey(tabelaRelacionamento => tabelaRelacionamento.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
