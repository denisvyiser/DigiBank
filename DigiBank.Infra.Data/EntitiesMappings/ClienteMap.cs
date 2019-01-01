
using DigiBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBank.Infra.Data.EntitiesMappings
{
    public class ClienteMap : IEntityTypeConfiguration<Cliente>
    {
        public void Configure(EntityTypeBuilder<Cliente> builder)
        {

            builder.HasKey(c => c.Id);

            builder
                .HasMany(e => e.ClientePerfil)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);


            builder
                .HasMany(e => e.ContaCorrente)
                .WithOne(e => e.Cliente)
                .HasForeignKey(e => e.ClienteId);

            builder
               .HasMany(e => e.Token)
               .WithOne(e => e.Cliente)
               .HasForeignKey(e => e.ClienteId);
        }
    }
}
