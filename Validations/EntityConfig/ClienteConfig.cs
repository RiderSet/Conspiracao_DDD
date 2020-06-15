using Domain.Entities.Models;
using System.Data.Entity.ModelConfiguration;

namespace Infra.Data.EntityConfig
{
    public class ClienteConfig : EntityTypeConfiguration<Cliente>
    {
        public ClienteConfig()
        {
            HasKey(c=>c.Id);

            Property(c => c.Nome)
                .IsRequired()
                .HasMaxLength(200);

        }
    }
}
