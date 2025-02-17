using MementoDominio.Comandos.Contrato;

namespace MementoDominio.Comandos.Lista
{
    public class ListaListarComandoSaida : ContratoListarComandoSaida
    {
        public string Nome { get; set; }
        public string Descricao { get; set; }
    }
}
