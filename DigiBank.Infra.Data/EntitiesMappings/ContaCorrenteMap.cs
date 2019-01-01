using DigiBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBank.Infra.Data.EntitiesMappings
{
    public class ContaCorrenteMap : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {

            builder.HasKey(c => c.Id);

            builder
                .Property(e => e.Numero)
                .IsFixedLength();


            builder
                .HasMany(e => e.TransacaoContaOrigem)
                .WithOne(e => e.ContaCorrenteOrigem)
                .HasForeignKey(e => e.ContaOrigem);

            builder
                .HasMany(e => e.TransacaoContaDestino)
                .WithOne(e => e.ContaCorrenteDestino)
                .HasForeignKey(e => e.ContaDestino);
        }
    }
}
