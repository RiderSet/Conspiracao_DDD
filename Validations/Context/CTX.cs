using Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace Infra.Data.Context
{
    public class CTX : DbContext
    {
        public CTX(DbContextOptions<CTX> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            foreach (var property in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");
            //   base.OnModelCreating(builder);

            builder.ApplyConfigurationsFromAssembly(typeof(CTX).Assembly);
            foreach (var relationship in builder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;
            base.OnModelCreating(builder);
        }

    }
}