using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Filmes.WebApi.Domains;
using Senai.Filmes.WebApi.Repositories;

namespace Senai.Filmes.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class GenerosController : ControllerBase
    {

        GenerosRepository GeneroRepository = new GenerosRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(GeneroRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain generoDomain)
        {
            GeneroRepository.Cadastrar(generoDomain);
            return Ok();
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            GeneroRepository.BuscarPorId(Id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Alterar(GeneroDomain generoDomain)
        {
            GeneroRepository.Alterar(generoDomain);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            GeneroRepository.Deletar(Id);
            return Ok();
        }
    }
}