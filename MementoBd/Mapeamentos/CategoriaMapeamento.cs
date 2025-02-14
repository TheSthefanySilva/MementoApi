using MementoBd.Entidades;
using MementoBd.Mapeamentos.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Migrations;
using Microsoft.EntityFrameworkCore.SqlServer;

namespace MementoBd.Mapeamentos
{
    public class CategoriaMapeamento : PadraoMapeamento<CategoriaEntidade>
    {
        public CategoriaMapeamento() : base("Categoria")
        {
        }

        public override void IncluirConfiguracao(EntityTypeBuilder<CategoriaEntidade> builder)
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
               .WithMany(tabelaPrincipal => tabelaPrincipal.Categorias)
               .HasForeignKey(tabelaRelacionamento => tabelaRelacionamento.UsuarioId)
               .OnDelete(DeleteBehavior.Restrict);

            // https://cursos.alura.com.br/forum/topico-erro-may-cause-cycles-or-multiple-cascade-paths-194294
            // https://stackoverflow.com/questions/63306882/specify-on-delete-no-action-or-on-update-no-action-or-modify-other-foreign-key


        }
    }
}
