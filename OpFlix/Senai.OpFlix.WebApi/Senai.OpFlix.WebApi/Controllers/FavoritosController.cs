using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
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
        private IUsuariosRepository UsuariosRepository { get; set; }

        public FavoritosController()
        {
            FavoritosRepository = new FavoritosRepository();
            UsuariosRepository = new UsuariosRepository();
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
                //int UsuarioId = Convert.ToInt32(HttpContext.User.Claims.First(x => x.Type 
                //== JwtRegisteredClaimNames.Jti).Value);
                //favoritos.IdUsuario = UsuarioId;
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