namespace MementoBd.Entidades
{
    public class UsuarioEntidade : EntidadeBase
    {
        public string Nome { get;set; }
        public string Email { get;set; }
        public string Senha { get;set; }
        public List<CategoriaEntidade> Categorias { get; set; }
        public List<ListaEntidade> Listas { get; set; }
    }
}
