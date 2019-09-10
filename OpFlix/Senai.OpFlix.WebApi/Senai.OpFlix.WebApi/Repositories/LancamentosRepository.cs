using Senai.OpFlix.WebApi.Domains;
using Senai.OpFlix.WebApi.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Repositories
{
    public class LancamentosRepository : ILancamentosRepository
    {
        /// <summary>
        /// Lista todos os lancamentos
        /// </summary>
        /// <returns>Lista de Lancamentos</returns>
        public List<Lancamentos> Listar()
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.ToList();
            }
        }

        /// <summary>
        /// Insere um novo lancamento
        /// </summary>
        /// <param name="lancamento"></param>
        public void Cadastrar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                ctx.Lancamentos.Add(lancamento);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Atualiza um lancamento
        /// </summary>
        /// <param name="lancamento"></param>
        public void Atualizar(Lancamentos lancamento)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos LancamentoBuscado = ctx.Lancamentos.FirstOrDefault
                (x => x.IdLancamento == lancamento.IdLancamento);
                LancamentoBuscado.Nome = lancamento.Nome;
                ctx.Lancamentos.Update(LancamentoBuscado);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Deleta um lancamento buscando o id
        /// </summary>
        /// <param name="id"></param>
        public void Deletar(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                Lancamentos lancamento = ctx.Lancamentos.Find(id);
                ctx.Lancamentos.Remove(lancamento);
                ctx.SaveChanges();
            }
        }

        /// <summary>
        /// Busca a lancamento através do id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>lancamento</returns>
        public Lancamentos BuscarPorId(int id)
        {
            using (OpFlixContext ctx = new OpFlixContext())
            {
                return ctx.Lancamentos.FirstOrDefault(x => x.IdLancamento == id);
            }
        }
    }
}
