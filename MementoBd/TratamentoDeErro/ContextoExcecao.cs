namespace MementoApi.Infra.TratamentoDeErro
{
    public class ContextoExcecao : Exception
    {
        public ContextoExcecao(string message)
        : base(message) { }
    }
}
