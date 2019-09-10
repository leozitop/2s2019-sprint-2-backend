﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class UsuariosController : ControllerBase
    {
        private IUsuariosRepository UsuariosRepository { get; set; }

        public UsuariosController()
        {
            UsuariosRepository = new UsuariosRepository();
        }

        /// <summary>
        /// Listar todas os usuarios
        /// </summary>
        /// <returns>lista de  usuario</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(UsuariosRepository.Listar());
        }


        /// <summary>
        /// Cadastrar usuarios
        /// </summary>
        /// <param name="usuario"></param>
        /// <returns>Ok</returns>
        [HttpPost] 
        public IActionResult Cadastrar(Usuarios usuario)
        {
            try
            {
                UsuariosRepository.Cadastrar(usuario);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }


        /// <summary>
        /// Deletar usuario
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            UsuariosRepository.Deletar(id);
            return Ok();
        }
    }
}