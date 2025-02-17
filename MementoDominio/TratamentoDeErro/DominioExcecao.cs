namespace MementoDominio.TratamentoDeErro
{
    public class DominioExcecao : Exception
    {
        public DominioExcecao(string message) : base(message) { }
    }
}
