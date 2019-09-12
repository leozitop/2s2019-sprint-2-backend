using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
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

        [HttpGet]
        public IActionResult Favoritos()
        {
            return Ok(FavoritosRepository.Favoritos());
        }

        [HttpPost]
        public IActionResult Favoritar(Lancamentos favorito)
        {
            try
            {
                FavoritosRepository.AddFavorito(favorito);
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new { mensagem = ex.Message });
            }
        }
    }
}