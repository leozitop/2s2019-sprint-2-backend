using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class FavoritosRepository : IFavoritosRepository
    {
        /// <summary>
        /// Lista os lancamentos favoritados e os usuarios que favoritaram
        /// </summary>
        /// <returns>Lista de Favoritos</returns>
        public List<Favoritos> ListarFavoritos()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Favoritos.Include(x => x.Usuario).ToList();
            }
        }

        /// <summary>
        /// Adiciona um novo favorito
        /// </summary>
        /// <param name="favoritos"></param>
        public void AddFavorito(Favoritos favoritos)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Favoritos.Add(favoritos);
                ctx.SaveChanges();
            }
        }
    }
}
