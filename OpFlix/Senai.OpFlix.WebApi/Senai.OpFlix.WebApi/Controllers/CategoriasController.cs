using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
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
    public class CategoriasController : ControllerBase
    {
        private ICategoriasRepository CategoriasRepository { get; set; }

        public CategoriasController()
        {
            CategoriasRepository = new CategoriasRepository();
        }

        /// <summary>
        /// Lista todas as categorias
        /// </summary>
        /// <returns>Lista de Categorias</returns>
        [AllowAnonymous]
        [HttpGet] 
        public IActionResult Listar()
        {
            return Ok(CategoriasRepository.Listar());
        }

        /// <summary>
        /// Cadastrar categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Ok(cadastro de categoria)</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriasRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Atualzar categoria
        /// </summary>
        /// <param name="categoria"></param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Categorias categoria)
        {
            try
            {
                Categorias CategoriaBuscada = CategoriasRepository.BuscarPorId(id);
                if (CategoriaBuscada == null)
                    return NotFound();
                categoria.IdCategoria = id;
                CategoriasRepository.Atualizar(categoria);
                return Ok();

            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Deletar categoria
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriasRepository.Deletar(id);
            return Ok();
        }
    }
}