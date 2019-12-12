using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.OpFlix.WebApi.Interfaces;
using Senai.OpFlix.WebApi.Repositories;

namespace Senai.OpFlix.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("application/json")]
    [ApiController]
    public class TiposController : ControllerBase
    {
        private ITiposRepository TiposRepository { get; set; }

        public TiposController()
        {
            TiposRepository = new TiposRepository();
        }

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(TiposRepository.Listar());
        }
    }
}