using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Ekips.WebApi.Domains;
using Senai.Ekips.WebApi.Repositories;

namespace Senai.Ekips.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CargosController : ControllerBase
    {
        CargosRepository CargosRepository = new CargosRepository();

        [HttpGet]
        public IActionResult ListarCargos()
        {
            return Ok(CargosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Cargos Cargo = CargosRepository.BuscarPorId(id);
            if (Cargo == null)
                return NotFound();
            return Ok(Cargo);
        }

        [HttpPost]
        public IActionResult Cadastrar(Cargos cargo)
        {
            try
            {
                CargosRepository.Cadastrar(cargo);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro no seu cadastro" + ex.Message });
            }
        }

        [HttpPut]
        public IActionResult Atualizar(Cargos cargo)
        {
            try
            {
                Cargos CargoBuscado = CargosRepository.BuscarPorId
                    (cargo.IdCargo);

                if (CargoBuscado == null)
                    return NotFound();

                CargosRepository.Atualizar(cargo);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}