using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                Usuarios UsuarioBuscado = ctx.Usuarios.FirstOrDefault(x => x.Email == login.Email
                && x.Senha == login.Senha);
                if (UsuarioBuscado == null)
                    return null;
                return UsuarioBuscado;
            }
        }

        public List<Usuarios> Listar()
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        public void Cadastrar(Usuarios usuarios)
        {
            using (AutoPecasContext ctx = new AutoPecasContext())
            {
                ctx.Usuarios.Add(usuarios);
                ctx.SaveChanges();
            }
        }
    }
}
