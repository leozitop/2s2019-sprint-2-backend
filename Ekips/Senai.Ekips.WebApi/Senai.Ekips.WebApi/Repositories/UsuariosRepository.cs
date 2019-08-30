using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class UsuariosRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email
                && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                    return null;
                return UsuarioBuscado;
            }
        }
    }
}
