using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Senai.Sstop.WebApi.Domains;
using Senai.Sstop.WebApi.NovaPasta;

namespace Senai.Sstop.WebApi.Controllers
{
    [Route("api/[controller]")]
    [Produces("Application/json")]
    [ApiController]
    public class EstilosController : ControllerBase
    {
        List<EstilosDomain> estilos = new List<EstilosDomain>()
                {
                new EstilosDomain { IdEstilo = 1,   Nome = "Rock"}
                ,new EstilosDomain { IdEstilo = 2,  Nome = "Pop"}
        };

        EstilosRepository EstilosRepository = new EstilosRepository();

        [Produces("Application/json")]
        [HttpGet]
        public IEnumerable<EstilosDomain> Listar()
        {
            
            return estilos;
        }

        
        [HttpGet("{Id}")]
        public IActionResult BuscarPorId(int Id)
        {
            EstilosDomain Estilo = EstilosRepository.BuscarPorId(Id);
            // EstilosDomain Estilo = estilos.Find(x => x.IdEstilo == Id);
            if (Estilo == null)
            {
                return NotFound();
            }
            return Ok(Estilo);
        }

        [HttpPost]
        public IActionResult Cadastrar(EstilosDomain estilosDomain)
        {
            EstilosRepository.Cadastrar(estilosDomain);
            //estilos.Add(new EstilosDomain
            //{
                //IdEstilo = estilos.Count + 1,
                //Nome = estilosDomain.Nome
            //});
            return Ok();
        }

        [HttpPut]
        public IActionResult Atualizar(EstilosDomain estilosDomain)
        {
            EstilosRepository.Alterar(estilosDomain);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public IActionResult Deletar(int Id)
        {
            EstilosRepository.Deletar(Id);
            return Ok();
        }
    }
}