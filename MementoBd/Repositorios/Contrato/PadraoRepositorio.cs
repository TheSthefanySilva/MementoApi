using MementoApi.Infra;

namespace MementoBd.Repositorios
{
    public abstract class PadraoRepositorio<TEntidade> where TEntidade : class
    {
        protected readonly ContextoBd _contextoBd;

        public PadraoRepositorio(ContextoBd contextoBd)
        {
            _contextoBd = contextoBd;
        }

        public virtual DateTime DataHora() =>
            DateTime.UtcNow;

        public virtual async Task Salvar() =>
            await _contextoBd.SaveChangesAsync();

        public virtual async Task Incluir(TEntidade entidadeCadastro) =>
            await _contextoBd.Set<TEntidade>().AddAsync(entidadeCadastro);

        public virtual async Task<TEntidade> LocalizarPorId(int id) =>
            await _contextoBd.Set<TEntidade>().FindAsync(id);

        public virtual Task Excluir(TEntidade entidade)
        {
            _contextoBd.Remove(entidade);

            return Task.CompletedTask;
        }
        public virtual Task ExcluirLista(List<TEntidade> entidade)
        {
            _contextoBd.RemoveRange(entidade);

            return Task.CompletedTask;
        }

        public async Task AbrirTransacao(Func<Task> metodo)
        {
            if (_contextoBd.Database.CurrentTransaction is null)
            {
                using (var transacao = await _contextoBd.Database.BeginTransactionAsync())
                {
                    await metodo();

                    await transacao.CommitAsync();
                }
            }
            else
            {
                await metodo();
            }
        }
    }
}
