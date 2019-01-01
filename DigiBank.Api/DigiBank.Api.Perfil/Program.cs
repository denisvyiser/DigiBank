using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;

namespace DigiBank.Api.Perfil
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                        .AddJsonFile("C:/DigiEnv/Sharedappsettings.json", optional: true);


                config.AddEnvironmentVariables();
            })
            .UseStartup<Startup>();
    }
}
