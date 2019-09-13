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
        //private IFavoritosRepository FavoritosRepository { get; set; }

        //public FavoritosController()
        //{
        //    FavoritosRepository = new FavoritosRepository();
        //}

        //[HttpGet]
        //public IActionResult Favoritos()
        //{
        //    return Ok(FavoritosRepository.ListarFavoritos());
        //}

        //[HttpPost("{id}")]
        //public IActionResult Favoritar(int id)
        //{
        //    FavoritosRepository.AddFavorito(id);
        //    return Ok();
        //}
    }
}