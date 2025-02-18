using MementoBd;
using MementoDominio.Comandos.Login;
using MementoDominio.TratamentoDeErro;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                Token = GerarTokenJwt(usuario.Id),
                NomeUsuario = usuario.Nome,
                IdUsuario = usuario.Id
            };
        }

        private string GerarTokenJwt(int idUsuario)
        {
            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes("w55FaTW1gEt20ltkPdG2bcUCztmnYB6P"));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
                issuer: "issuer",
                audience: "audience",
                claims: new List<Claim>() { new Claim("IdUsuario", idUsuario.ToString()) },
                expires: DateTime.Now.AddDays(1),
                signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
