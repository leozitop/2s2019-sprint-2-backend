using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class PlataformasRepository : IPlataformasRepository
    {
        /// <summary>
        /// Lista todas as plataformas
        /// </summary>
        /// <returns>Lista de Plataformas</returns>
        public List<Plataformas> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.ToList();
            }
        }

        /// <summary>
        /// Insere uma nova plataforma
        /// </summary>
        /// <param name="plataforma"></param>
        public void Cadastrar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Plataformas.Add(plataforma);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza uma plataforma
        /// </summary>
        /// <param name="plataforma"></param>
        public void Atualizar(Plataformas plataforma)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas PlataformaBuscada = ctx.Plataformas.FirstOrDefault
                (x => x.IdPlataforma == plataforma.IdPlataforma);
                PlataformaBuscada.Nome = plataforma.Nome;
                ctx.Plataformas.Update(PlataformaBuscada
                    );
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a plataforma através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>plataforma</returns>
        public Plataformas BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Plataformas.FirstOrDefault(x => x.IdPlataforma == id);
            }
        }

        /// <summary>
        /// Deleta a plataforma buscando o id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Plataformas plataforma = ctx.Plataformas.Find(id);
                ctx.Plataformas.Remove(plataforma);
                ctx.SaveChanges();
            }
        }
    }
}
