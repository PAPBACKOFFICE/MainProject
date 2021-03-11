using PAPBackOffice.Data.Entities;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace PAPBackOffice.Services
{
    public interface IConfiguracaoServico
    {       
        Task<List<Configuracao>> ListarTodas();
        Task<List<Configuracao>> Listar(Expression<Func<Configuracao, bool>> query);
        Task<Configuracao> ObterConfiguracaoPorNome(string Nome);
    }
}