﻿using Senai.AutoPecas.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.AutoPecas.WebApi.Interfaces
{
    public interface IPecaRepository
    {
        List<Pecas> Listar();
        void Cadastrar (Pecas peca);
        Pecas BuscarPorId (int id);
        void Atualizar (Pecas peca);
        void Deletar (int id);
    }
}
