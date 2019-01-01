using DigiBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace DigiBank.Infra.Data.EntitiesMappings
{
    class PerfilMap : IEntityTypeConfiguration<Perfil>
    {
        public void Configure(EntityTypeBuilder<Perfil> builder)
        {

            builder.HasKey(c => c.Id);

            builder
               .HasMany(e => e.ClientePerfil)
               .WithOne(e => e.Perfil)
               .HasForeignKey(e => e.PerfilId);

                       
        }
    }
}
