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
    public class ProdutoRep : Repository<Produto>, IProdutoRep
    {
        public ProdutoRep(CTX bd) : base(bd) { }

        public async Task<Produto> ObterPorCliente(Guid id)
        {
            return await db.Produtos.AsNoTracking().Include(c => c.Cliente)
                .FirstOrDefaultAsync(p => p.clienteId == id);
        }

        public async Task<List<Produto>> ObterVariosPorCliente(Guid id)
        {
            return await db.Produtos.AsNoTracking().Include(c => c.Cliente)
                .Where(p => p.clienteId == id).ToListAsync();
        }
    }
}
