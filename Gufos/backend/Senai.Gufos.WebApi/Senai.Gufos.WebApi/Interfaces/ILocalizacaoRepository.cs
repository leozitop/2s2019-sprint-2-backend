using Senai.Gufos.WebApi.Domains;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Senai.Gufos.WebApi.Interfaces
{
    public interface ILocalizacaoRepository
    {
        void cadastrar(Localizacoes localizacoes);
        List<Localizacoes> Listar();
    }
}
