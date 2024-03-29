﻿using System;
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
    public class AutoresController : ControllerBase
    {
        AutoresRepository AutoresRepository = new AutoresRepository();

        [HttpGet]
        public IActionResult Listar()
        {
            return Ok(AutoresRepository.Listar());
        }

        [HttpPost]
        public IActionResult Cadastrar(AutorDomain Autor)
        {
            AutoresRepository.Cadastrar(Autor);
            return Ok();
        }
    }
}