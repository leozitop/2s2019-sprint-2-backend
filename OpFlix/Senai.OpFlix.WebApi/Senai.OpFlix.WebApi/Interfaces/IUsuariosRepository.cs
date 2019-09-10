﻿using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface IUsuariosRepository
    {
        List<Usuarios> Listar();
        void Cadastrar(Usuarios usuario);
        void Deletar(int id);
        Usuarios BuscarPorEmailESenha(LoginViewModel login);
    }
}
