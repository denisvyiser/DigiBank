using DigiBank.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;


namespace DigiBank.Infra.Data.EntitiesMappings
{
    class ClientePerfilMap : IEntityTypeConfiguration<ClientePerfil>
    {
        public void Configure(EntityTypeBuilder<ClientePerfil> builder)
        {

            builder.HasKey(c => c.Id);
            
        }
    }
}