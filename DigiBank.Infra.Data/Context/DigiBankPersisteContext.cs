using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;

namespace DigiBank.Infra.Data.Context
{
    public class DigiBankPersisteContext : IDesignTimeDbContextFactory<DigiBankContext>
    {

        private const string CONNECTIONSTRING = @"Data Source=localhost\\SQLEXPRESS;Initial Catalog=DigiBank;user id=sa;password=12345;";
        public DigiBankContext CreateDbContext(string[] args)
        {

            

        var builder = new DbContextOptionsBuilder<DigiBankContext>();
            
            builder.UseSqlServer(CONNECTIONSTRING);

            return new DigiBankContext(builder.Options);
        }
    }
}
