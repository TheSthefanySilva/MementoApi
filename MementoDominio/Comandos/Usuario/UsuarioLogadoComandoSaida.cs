using MementoDominio.Comandos.Contrato;

namespace MementoDominio.Comandos.Usuario
{
    public class UsuarioLogadoComandoSaida : ContratoListarComandoSaida
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}
