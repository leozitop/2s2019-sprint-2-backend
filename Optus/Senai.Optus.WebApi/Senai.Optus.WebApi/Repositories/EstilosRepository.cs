using Senai.Optus.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Optus.WebApi.Repositories
{
    public class EstilosRepository
    {
        public List<Estilos> Listar()
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.ToList();
            }
        }

        public Estilos BuscarPorId(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                return ctx.Estilos.FirstOrDefault(x => x.IdEstilo == id);
            }
        }

        public void Cadastrar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // INSERT INTO
                ctx.Estilos.Add(estilo);
            }
        }

        public void Atualizar(Estilos estilo)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // busco a categoria
                Estilos EstiloBuscado = ctx.Estilos.FirstOrDefault(x => x.IdEstilo == estilo.IdEstilo);
                // SET
                EstiloBuscado.Nome =  estilo.Nome;
                // atualizo
                ctx.Estilos.Update(EstiloBuscado);
                // salvo no banco
                ctx.SaveChanges();
            }
        }

        public void Deletar(int id)
        {
            using (OptusContext ctx = new OptusContext())
            {
                // Busco pelo id
                Estilos estilo = ctx.Estilos.Find(id);
                // removo de estilo
                ctx.Estilos.Remove(estilo);
                // salvo no banco
                ctx.SaveChanges();
            }
        }
    }
}
