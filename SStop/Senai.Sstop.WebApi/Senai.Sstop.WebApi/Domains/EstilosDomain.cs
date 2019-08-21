using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Sstop.WebApi.Domains
{
    public class EstilosDomain
    {
        public int IdEstilo { get; set; }
        [Required(ErrorMessage = "O nome é obrigatório anta")]
        public string Nome { get; set; }
    }

}
