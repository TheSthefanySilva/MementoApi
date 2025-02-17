using MementoBd;
using MementoDominio.Comandos.Login;
using MementoDominio.TratamentoDeErro;

namespace MementoDominio.Manipuladores
{
    public class LoginManipulador 
    {
        private ContextoBd contexto { get; set; }
        public LoginManipulador(ContextoBd contextoBd)
        {
            this.contexto = contextoBd;
        }

        public LoginComandoSaida RealizarLogin(LoginComandoEntrada dados)
        {
            contexto.TestarConexao();
            contexto.ExecutarMigracao();
            
            var usuario = contexto.Usuario.FirstOrDefault(x => x.Email == dados.Email && x.Senha == dados.Senha);
            if (usuario == null)
                throw new DominioExcecao("Usuário não encontrado ou senha inválida.");

            return new LoginComandoSaida()
            {
                Token = "autorizado",
                NomeUsuario = usuario.Nome,
                IdUsuario = usuario.Id
            };
        }
    }
}
