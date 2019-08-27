using Microsoft.EntityFrameworkCore;
using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class ArtistasRepository
    {
        public List<Artistas> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.Include(x => x.IdEstiloNavigation).ToList();
            }
        }

        public Artistas BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.FirstOrDefault(x => x.IdArtista == id);
            }
        }

        public Artistas BuscarPorNome(string nome)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Artistas.FirstOrDefault(x => x.Nome == nome);
            }
        }

        public void Cadastrar(Artistas artista)
        {
            using (OptusContext ctx = new OptusContext())
            {
                ctx.Artistas.Add(artista);
            }
        }
    }
}
