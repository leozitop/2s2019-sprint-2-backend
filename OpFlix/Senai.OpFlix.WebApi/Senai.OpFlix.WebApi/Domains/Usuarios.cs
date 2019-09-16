﻿using System;
using System.Collections.Generic;

namespace Senai.OpFlix.WebApi.Domains
{
    public partial class Usuarios
    {
        public int IdUsuario { get; set; }
        public string Nome { get; set; }
        public int IdTipoUsuario { get; set; }
        public string Senha { get; set; }
        public string Email { get; set; }

        public TiposUsuarios IdTipoUsuarioNavigation { get; set; }
        public List<Favoritos> Favoritos { get; set; }
    }
}
