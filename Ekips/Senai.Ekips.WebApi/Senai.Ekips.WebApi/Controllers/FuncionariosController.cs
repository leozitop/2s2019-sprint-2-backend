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
    public class FuncionariosController : ControllerBase
    {
        FuncionariosRepository FuncionariosRepository = new FuncionariosRepository();

        [HttpGet]
        public IActionResult ListarFuncionarios()
        {
            return Ok(FuncionariosRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Funcionarios Funcionario = FuncionariosRepository.BuscarPorId(id);
            if (Funcionario == null)
                return NotFound();
            return Ok(Funcionario);
        }

        [HttpPost]
        public IActionResult Cadastrar(Funcionarios funcionario)
        {
            FuncionariosRepository.Cadastrar(funcionario);
            return Ok();
        }
    }
}