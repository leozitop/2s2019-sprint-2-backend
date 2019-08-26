using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Optus.WebApi.Domains;
using Senai.Optus.WebApi.Repositories;

namespace Senai.Optus.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        EstilosRepository EstilosRepository = new EstilosRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(EstilosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Estilos Estilo = EstilosRepository.BuscarPorId(id);
            if (Estilo == null)
                return NotFound();
            return Ok(Estilo);
        }

        [HttpPost]
        public IActionResult Cadastrar(Estilos estilo)
        {
            try
            {
                EstilosRepository.Cadastrar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Estilos estilo)
        {
            try
            {
                Estilos EstiloBuscado = EstilosRepository.BuscarPorId
                    (estilo.IdEstilo);
                if (EstiloBuscado == null)
                    return NotFound();

                EstilosRepository.Atualizar(estilo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            EstilosRepository.Deletar(id);
            return Ok();
        }
    }
}