using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class CategoriasRepository : ICategoriasRepository
    {
        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Lista de Categorias</returns>
        public List<Categorias> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //retorna a lista de Categorias
                return ctx.Categorias.ToList();
            }
        }

        /// <summary>
        /// Insere uma nova categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void Cadastrar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //insere o registro
                ctx.Categorias.Add(categoria);
                //salva no bd
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza uma categoria
        /// </summary>
        /// <param name="categoria"></param>
        public void Atualizar(Categorias categoria)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //busca a categoria
                Categorias CategoriaBuscada = ctx.Categorias.FirstOrDefault(x => 
                x.IdCategoria == categoria.IdCategoria);
                CategoriaBuscada.Nome = categoria.Nome;
                //atualiza categoria
                ctx.Categorias.Update(CategoriaBuscada);
                //salva no bd
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta a categoria buscando o id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                //busca o id da categoria
                Categorias categoria = ctx.Categorias.Find(id);
                //remove
                ctx.Categorias.Remove(categoria);
                //salva no bd
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a categoria através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>categoria</returns>
        public Categorias BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Categorias.FirstOrDefault(x => x.IdCategoria == id);
            }
        }

    }
}
