using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.BookStore.WebApi.Domains;
using Senai.BookStore.WebApi.Repositories;

namespace Senai.BookStore.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class LivrosController : ControllerBase
    {
        LivrosRepository LivrosRepository = new LivrosRepository();

        [Produces("Application/json")]
        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(LivrosRepository.Listar());
        }


        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            LivroDomain Livro = LivrosRepository.BuscarPorId(Id);
            // LivrosDomain Estilo = livros.Find(x => x.IdEstilo == Id);
            if (Livro == null)
            {
                return NotFound();
            }
            return Ok(Livro);
        }

        [HttpPost]
        public IActionResult Cadastrar(LivroDomain livrosDomain)
        {
            LivrosRepository.Cadastrar(livrosDomain);
            //livros.Add(new LivrosDomain
            //{
            //IdEstilo = livros.Count + 1,
            //Nome = livrosDomain.Nome
            //});
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(LivroDomain livrosDomain)
        {
            LivrosRepository.Atualizar(livrosDomain);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            LivrosRepository.Deletar(Id);
            return Ok();
        }
    }
}