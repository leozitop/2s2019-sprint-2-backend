using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class TiposRepository : ITiposRepository
    {
        public List<Tipos> Listar()
        {
            using(OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Tipos.ToList();
            }
        }
    }
}
