using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class UsuariosRepository : IUsuariosRepository
    {
        /// <summary>
        /// Busca o usuario através do email e senha passados
        /// </summary>
        /// <param name="login"></param>
        /// <returns>um usuario</returns>
        public Usuarios BuscarPorEmailESenha(LoginViewModel login)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios usuario = ctx.Usuarios.FirstOrDefault(x => 
                x.Email == login.Email && x.Senha == login.Senha);
                if (usuario == null)
                    return null;
                return usuario;
            }
        }

        /// <summary>
        /// Lista todos os Usuarios
        /// </summary>
        /// <returns>Lista de Usuarios</returns>
        public List<Usuarios> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Usuarios.ToList();
            }
        }

        /// <summary>
        /// Insere um novo usuario
        /// </summary>
        /// <param name="usuario"></param>
        public void Cadastrar(Usuarios usuario)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Usuarios.Add(usuario);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta um usuario
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Usuarios usuario = ctx.Usuarios.Find(id);
                ctx.Usuarios.Remove(usuario);
                ctx.SaveChanges();
            }
        }
    }
}
