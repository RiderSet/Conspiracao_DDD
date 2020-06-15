using Domain.Entities.Models;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.EntityConfig
{
    public class ProdutoConfig : EntityTypeConfiguration<Produto>
    {
        public ProdutoConfig()
        {
            HasKey(c => c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(100);
        }
    }
}
