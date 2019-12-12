using Microsoft.EntityFrameworkCore;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
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
            //usuario.Senha = HashValue(usuario.Senha);
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

        //public static string HashValue(string value)
        //{
        //    UnicodeEncoding encoding = new UnicodeEncoding();
        //    byte[] hashBytes;
        //    using (HashAlgorithm hash = SHA1.Create())
        //        hashBytes = hash.ComputeHash(encoding.GetBytes(value));

        //    StringBuilder hashValue = new StringBuilder(hashBytes.Length * 2);
        //    foreach (byte b in hashBytes)
        //    {
        //        hashValue.AppendFormat(CultureInfo.InvariantCulture, "{0:X2}", b);
        //    }

        //    return hashValue.ToString();
        //}
    }
}
