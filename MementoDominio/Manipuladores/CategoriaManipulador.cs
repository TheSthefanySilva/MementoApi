﻿

using MementoBd;
using MementoBd.Entidades;
using MementoDominio.Comandos;
using MementoDominio.Comandos.Categoria;
using MementoDominio.TratamentoDeErro;

namespace MementoDominio.Manipuladores
{
    public class CategoriaManipulador 
    {
        public ContextoBd contexto { get; set; }
        public CategoriaManipulador(ContextoBd contextoBd)
        {
            this.contexto = contextoBd;
        }

        public List<CategoriaListarComandoSaida> Listar()
        {
            return contexto.Categoria.Select(x => new CategoriaListarComandoSaida()
            {
                Id = x.Id,
                Nome = x.Nome,
                Descricao = x.Descricao,
                Inativo = x.Inativo,
                DataCriacao = x.CriadoEm
            }).ToList();
        }

        public void Incluir(CategoriaCadastroComandoEntrada dados)
        {
            var novoItem = new CategoriaEntidade();
            PreencherItem(novoItem, dados);
            contexto.Add(novoItem);
            contexto.SaveChanges();
        }

        public void Alterar(int id, CategoriaCadastroComandoEntrada dados)
        {
            var item = contexto.Categoria.FirstOrDefault(x => x.Id == id);
            if (item == null)
                throw new DominioExcecao("Categoria não encontrada");

            PreencherItem(item, dados);
            contexto.SaveChanges();
        }

        private void PreencherItem(CategoriaEntidade entidade, CategoriaCadastroComandoEntrada dados)
        {
            entidade.Nome = dados.Nome;
            entidade.Descricao = dados.Descricao;
            entidade.Inativo = dados.Inativo;
            entidade.UsuarioId = 1;
            
            if (entidade.Id > 0)
                entidade.AtualizadoEm = DateTime.Now;
            else
                entidade.CriadoEm = DateTime.Now;
        }
    }
}
