using DigiBank.Domain.Entities;
using DigiBank.Infra.Data.EntitiesMappings;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace DigiBank.Infra.Data.Context
{
    public class DigiBankContext : DbContext
    {

        private readonly IConfiguration _configuration;

    public DigiBankContext(IConfiguration _configuration)
    {
        this._configuration = _configuration;
    }

        //-----------------Configuração do Migration--------------------------

        private const string CONNECTIONSTRING = @"Data Source=localhost\\SQLEXPRESS;Initial Catalog=DigiBank;user id=sa;password=12345;";
        public DigiBankContext(DbContextOptions<DigiBankContext> options) : base(options)
        {

        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {


           optionsBuilder.UseSqlServer(_configuration.GetConnectionString("DataConnection"));

            //-----------------Configuração do Migration ConnectionString--------------------------
            //   optionsBuilder.UseSqlServer(CONNECTIONSTRING);

        }

        #region Entities DBset
        public virtual DbSet<Cliente> Cliente { get; set; }
    public virtual DbSet<ContaCorrente> ContaCorrente { get; set; }
    public virtual DbSet<Transacao> Transacao { get; set; }
    public virtual DbSet<Token> Token { get; set; }

    public virtual DbSet<Perfil> Perfil { get; set; }
    public virtual DbSet<ClientePerfil> ClientePerfil { get; set; }

        #endregion

        protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new ClienteMap());
        modelBuilder.ApplyConfiguration(new ContaCorrenteMap());
        modelBuilder.ApplyConfiguration(new TransacaoMap());
        modelBuilder.ApplyConfiguration(new TokenMap());
        modelBuilder.ApplyConfiguration(new PerfilMap());
        modelBuilder.ApplyConfiguration(new ClientePerfilMap());


            base.OnModelCreating(modelBuilder);
    }


}
}