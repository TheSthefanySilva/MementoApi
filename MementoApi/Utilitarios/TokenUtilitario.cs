﻿using System.Security.Claims;

namespace MementoApi.Utilitarios
{
    public static class TokenUtilitario
    {
        public static int RetornarIdUsuario(HttpContext context)
        {
            var idUsuario = 0;

            var identity = context.User.Identity as ClaimsIdentity;
            if (identity != null)
            {
                int.TryParse(identity.FindFirst("IdUsuario")?.Value, out idUsuario);
            }

            if (idUsuario <= 0)
                throw new Exception("IdUsuario não foi encontrado no token");

            return idUsuario;
        }
    }
}
