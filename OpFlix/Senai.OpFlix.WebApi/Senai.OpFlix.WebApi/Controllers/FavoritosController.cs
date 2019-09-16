using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class FavoritosController : ControllerBase
    {
        private IFavoritosRepository FavoritosRepository { get; set; }

        public FavoritosController()
        {
            FavoritosRepository = new FavoritosRepository();
        }

        /// <summary>
        /// Lista os lancamentos favoritados e os usuarios que favoritaram
        /// </summary>
        /// <returns>Lista de Favoritos</returns>
        [AllowAnonymous]
        [HttpGet]
        public IActionResult ListarFavoritos()
        {
            return Ok(FavoritosRepository.ListarFavoritos());
        }

        /// <summary>
        /// Adiciona um novo favorito
        /// </summary>
        /// <param name="favoritos"></param>
        [AllowAnonymous]
        [HttpPost]
        public IActionResult AddFavorito(Favoritos favoritos)
        {
            try
            {
                FavoritosRepository.AddFavorito(favoritos);
                return Ok();
            }
            catch(Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}