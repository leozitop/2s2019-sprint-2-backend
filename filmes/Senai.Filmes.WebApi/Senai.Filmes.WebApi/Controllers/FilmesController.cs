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
    [Produces("application/json")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        //Instanciar o repositorio
        FilmesRepository FilmeRepository = new FilmesRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(FilmeRepository.Listar());
        }

        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            FilmeRepository.BuscarPorId(Id);
            return Ok();
        }

        [HttpPost]
        public IActionResult Cadastrar(FilmeDomain Filme)
        {
            // tenta cadastrar o Filme
            try
            {
                FilmeRepository.Cadastrar(Filme);
                return Ok();
            }
            //caso ocorra algum erro
            catch (Exception ex)
            {
                // nao foi realizada com sucesso
                return BadRequest(new { mensagem = "Ocorreu um erro." + ex.Message });
            }
        }
    }
}