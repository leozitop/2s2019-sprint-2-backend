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
    public class DepartamentosController : ControllerBase
    {
        DepartamentosRepository DepartamentosRepository = new DepartamentosRepository();

        [HttpGet]
        public IActionResult ListarDepartamento()
        {
            return Ok(DepartamentosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Departamentos Departamento = DepartamentosRepository.BuscarPorId(id);
            if (Departamento == null)
                return NotFound();
            return Ok(Departamento);
        }

        [HttpPost]
        public IActionResult Cadastrar(Departamentos departamento)
        {
            try
            {
                DepartamentosRepository.Cadastrar(departamento);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro" + ex.Message });
            }
        }
    }
}