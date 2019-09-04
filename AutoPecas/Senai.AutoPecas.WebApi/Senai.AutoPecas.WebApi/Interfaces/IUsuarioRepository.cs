using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    interface IUsuarioRepository
    {
        List<Usuarios> Listar();
        void Cadastrar (Usuarios usuario);
    }
}
