using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.AutoPecas.WebApi.Domains;
using Senai.AutoPecas.WebApi.Interfaces;
using Senai.AutoPecas.WebApi.Repositories;

namespace Senai.AutoPecas.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuarioRepository UsuarioRepositrory { get; set; }

        public UsuariosController()
        {
            UsuarioRepositrory = new UsuarioRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuarioRepositrory.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Usuarios usuario)
        {
            UsuarioRepositrory.Cadastrar(usuario);
            return Ok();
        }
    }
}