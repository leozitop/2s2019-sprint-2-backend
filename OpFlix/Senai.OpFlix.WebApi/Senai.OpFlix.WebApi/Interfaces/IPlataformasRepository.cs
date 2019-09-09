using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IPlataformasRepository
    {
        List<Plataformas> Listar();
        void Cadastrar(Plataformas plataforma);
        void Atualizar(Plataformas plataforma);
        void Deletar(int id);
        Plataformas BuscarPorId(int id);
    }
}
