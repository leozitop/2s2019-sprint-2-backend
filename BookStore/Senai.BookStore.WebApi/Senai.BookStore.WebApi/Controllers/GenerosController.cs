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
    public class GenerosController : ControllerBase
    {
        GenerosRepository GenerosRepository = new GenerosRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(GenerosRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(GeneroDomain Genero)
        {
            GenerosRepository.Cadastrar(Genero);
            return Ok();
        }
    }
}