using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Gufos.WebApi.Domains;
using Senai.Gufos.WebApi.Repositories;

namespace Senai.Gufos.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        CategoriasRepository CategoriasRepository = new CategoriasRepository();

        [HttpGet]
        public IActionResult ListarTodos()
        {
            return Ok(CategoriasRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(Categorias categoria)
        {
            try
            {
                CategoriasRepository.Cadastrar(categoria);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = "Ih, deu erro." + ex.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult BuscarPorId(int id)
        {
            Categorias Categoria = CategoriasRepository.BuscarPorId(id);
            if (Categoria == null)
                return NotFound();
            return Ok(Categoria);
        }

        /// <summary>
        /// Deletar uma categoria por id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>Sucesso caso seja deletado.</returns>
        [HttpDelete("{id}")]
        public IActionResult Deletar(int id)
        {
            CategoriasRepository.Deletar(id);
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(Categorias categoria)
        {
            try
            {
                Categorias CategoriasBuscada = CategoriasRepository.BuscarPorId
                    (categoria.IdCategoria);

                if (CategoriasBuscada == null)
                    return NotFound();

                CategoriasRepository.Atualizar(categoria);
                return Ok();
            }
            catch
            {
                return BadRequest();
            }
        }
    }
}