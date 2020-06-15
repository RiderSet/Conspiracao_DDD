using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IClienteRep: IRepository<Cliente>
    {
        Task<List<Cliente>> ObterPorProduto(Guid id);
        Task<List<Produto>> ObterProdutos(Guid id);
    }
}
