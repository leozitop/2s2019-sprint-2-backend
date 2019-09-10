using System;
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
    public class LancamentosController : ControllerBase
    {
        private ILancamentosRepository LancamentosRepository { get; set; }

        public LancamentosController()
        {
            LancamentosRepository = new LancamentosRepository();
        }

        /// <summary>
        /// Listar todos os lancamentos
        /// </summary>
        /// <returns>lista de lancamentos</returns>
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LancamentosRepository.Listar());
        }

        /// <summary>
        /// Cadastrar lancamentos
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Ok</returns>
        [HttpPost]
        public IActionResult Cadastrar(Lancamentos lancamento)
        {
            try
            {
                LancamentosRepository.Cadastrar(lancamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Atualizar lancamento
        /// </summary>
        /// <param name="lancamento"></param>
        /// <returns>Ok</returns>
        [HttpPut("{id}")]
        public IActionResult Atualizar(int id, Lancamentos lancamento)
        {
            try
            {
                Lancamentos LancamentoBuscada = LancamentosRepository.BuscarPorId(id);
                if (LancamentoBuscada == null)
                    return NotFound();
                lancamento.IdLancamento = id;
                LancamentosRepository.Atualizar(lancamento);
                return Ok(LancamentoBuscada);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }

        /// <summary>
        /// Deletar lancamento
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Ok</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            LancamentosRepository.Deletar(id);
            return Ok();
        }

        /// <summary>
        /// Buscar lancamento por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>lancamento</returns>
        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            try
            {
                Lancamentos lancamento = LancamentosRepository.BuscarPorId(id);
                if (lancamento == null)
                    return NotFound();
                return Ok(lancamento);
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}