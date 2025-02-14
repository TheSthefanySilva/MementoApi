using MementoBd.Entidades;
using MementoBd.Mapeamentos.Contrato;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace MementoBd.Mapeamentos
{
    public class TarefaMapeamento : PadraoMapeamento<TarefaEntidade>
    {
        public TarefaMapeamento() : base("Tarefa")
        {
        }

        public override void IncluirConfiguracao(EntityTypeBuilder<TarefaEntidade> builder)
        {
            builder.Property(x => x.Titulo)
              .IsRequired()
              .HasColumnName("Nome")
              .HasColumnType("Varchar")
              .HasMaxLength(150);

            builder.Property(x => x.Descricao)
              .HasColumnName("Descricao")
              .HasColumnType("Varchar")
              .HasMaxLength(500);

            builder.Property(x => x.Status)
              .HasColumnName("Nome")
              .HasColumnType("Varchar")
              .HasMaxLength(150);

            builder.Property(x => x.DataLimite)
              .HasColumnName("DataLimite")
              .HasColumnType("Datetime");

            builder.Property(x => x.ListaId)
              .IsRequired()
              .HasColumnName("UsuarioId")
              .HasColumnType("Int");

            builder.Property(x => x.CategoriaId)
              .IsRequired()
              .HasColumnName("UsuarioId")
              .HasColumnType("Int");

            builder.Property(x => x.Prioridade)
              .IsRequired()
              .HasColumnName("UsuarioId")
              .HasColumnType("Int");

            builder.HasOne(x => x.Lista)
               .WithMany(tabelaPrincipal => tabelaPrincipal.Tarefas)
               .HasForeignKey(tabelaRelacionamento => tabelaRelacionamento.ListaId)
               .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne(x => x.Categoria)
               .WithMany(tabelaPrincipal => tabelaPrincipal.Tarefas)
               .HasForeignKey(tabelaRelacionamento => tabelaRelacionamento.CategoriaId)
               .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
