using Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Domain.Interfaces.Repositories
{
    public interface IProdutoRep : IRepository<Produto>
    {
        Task<Produto> ObterPorCliente(Guid id);
        Task<List<Produto>> ObterVariosPorCliente(Guid id);
    }
}
