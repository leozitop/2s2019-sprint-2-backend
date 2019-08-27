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
    public class ArtistasController : ControllerBase
    {
        ArtistasRepository ArtistasRepository = new ArtistasRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(ArtistasRepository.Listar());
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Artistas Artista = ArtistasRepository.BuscarPorId(id);
            if (Artista == null)
                return NotFound();
            return Ok(Artista);
        }

        [HttpGet("{nome}")]
        public IActionResult BuscarPorNome(string nome)
        {
            Artistas Artista = ArtistasRepository.BuscarPorNome(nome);
            if (Artista == null)
                return NotFound();
            return Ok(Artista);
        }

        [HttpPost]
        public IActionResult Cadastrar(Artistas artista)
        {
            try
            {
                ArtistasRepository.Cadastrar(artista);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ocorreu um erro no cadastro" + ex.Message });
            }
        }
    }
}