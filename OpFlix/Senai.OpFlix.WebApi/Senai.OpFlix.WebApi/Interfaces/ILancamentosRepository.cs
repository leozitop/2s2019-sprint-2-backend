using Senai.OpFlix.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.OpFlix.WebApi.Interfaces
{
    public interface ILancamentosRepository
    {
        List<Lancamentos> Listar();
        void Cadastrar(Lancamentos lancamento);
        void Atualizar(Lancamentos lancamento);
        void Deletar(int id);
        Lancamentos BuscarPorId(int id);
        //List<Lancamentos> FiltrarData(DateTime date);
        List<Lancamentos> BuscarPorCategoria(int categoria);
        List<Lancamentos> BuscarPorPlataforma(int plataforma);
        List<Lancamentos> BuscarPorTipo(int tipo);
        List<Lancamentos> BuscarPorData(DateTime data);
    }
}
