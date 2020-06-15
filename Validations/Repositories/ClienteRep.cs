using Domain.Entities.Models;
using Domain.Interfaces.Repositories;
using Infra.Data.Context;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;

namespace Infra.Data.Repositories
{
    public class ClienteRep : Repository<Cliente>, IClienteRep
    {
        public ClienteRep(CTX bd) : base(bd) { }

        public async Task<List<Cliente>> ObterPorProduto(Guid id)
        {
            return await db.Clientes.AsNoTracking().Include(c => c.Produtos)
                .Where(p => p.Id == id).ToListAsync();
        }

        public async Task<List<Produto>> ObterProdutos(Guid id)
        {
            return await db.Produtos.AsNoTracking().Include(c => c.Cliente)
                .Where(p => p.clienteId  == id).ToListAsync();
        }
    }
}
