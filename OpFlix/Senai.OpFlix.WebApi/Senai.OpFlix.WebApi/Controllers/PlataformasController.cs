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
    public class PlataformasController : ControllerBase
    {
        private IPlataformasRepository PlataformasRepository { get; set; }

        public PlataformasController()
        {
            PlataformasRepository = new PlataformasRepository();
        }

        /// <summary>
        /// Listar todas as plataformas
        /// </summary>
        /// <returns>lista de plataformas</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(PlataformasRepository.Listar());
        }

        /// <summary>
        /// Cadastrar plataforma
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPost]
        public IActionResult Cadastrar(Plataformas plataforma)
        {
            try
            {
                PlataformasRepository.Cadastrar(plataforma);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Atualizar categoria
        /// </summary>
        /// <param name="plataforma"></param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "1")]
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Plataformas plataforma)
        {
            try
            {
                Plataformas PlataformaBuscada = PlataformasRepository.BuscarPorId(id);
                if (PlataformaBuscada == null)
                    return NotFound();
                plataforma.IdPlataforma = id;
                PlataformasRepository.Atualizar(plataforma);
                return Ok(PlataformaBuscada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
        
        /// <summary>
        /// Deletar plataforma
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [Authorize(Roles = "1")]
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            PlataformasRepository.Deletar(id);
            return Ok();
        }

        [HttpGet("{nome}")]
        public IActionResult Filtrar(string nome)
        {
            try
            {
                Plataformas plataforma = PlataformasRepository.FiltarPlataforma(nome);
                if (plataforma == null)
                    return NotFound();
                return Ok(plataforma);
            }
            catch (Exception ex)
            {
                return BadRequest(new{ mensagem = ex.Message });
            }
        }
    }
}