

using MementoBd;

namespace MementoDominio.Manipuladores
{
    public class CategoriaManipulador 
    {
        public List<string> ListarCategorias()
        {
            var contexto = new ContextoBd();
            contexto.TestarConexao();
            contexto.ExecutarMigracao();


            var categorias = contexto.Categoria.ToList();
            return categorias.Select(x => x.Nome).ToList();
        }
    }
}
