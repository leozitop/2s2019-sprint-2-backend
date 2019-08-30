﻿using Microsoft.EntityFrameworkCore;
using Senai.Ekips.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Ekips.WebApi.Repositories
{
    public class FuncionariosRepository
    {
        public List<Funcionarios> Listar()
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.Include(x => x.IdCargoNavigation).Include(x => x.IdDepartamentoNavigation).Include(x => x.IdUsuarioNavigation).ToList();
            }
        }

        public Funcionarios BuscarPorId(int id)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                return ctx.Funcionarios.FirstOrDefault(x => x.IdFuncionario == id);
            }
        }

        public void Cadastrar(Funcionarios funcionario)
        {
            using (EkipsContext ctx = new EkipsContext())
            {
                ctx.Funcionarios.Add(funcionario);
            }
        }
    }
}