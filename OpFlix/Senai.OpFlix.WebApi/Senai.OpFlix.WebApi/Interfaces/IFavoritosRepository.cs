using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IFavoritosRepository
    {
        List<Favoritos> ListarFavoritos();
        void AddFavorito(Favoritos favoritos);
    }
}
