using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.TestHost;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace DigiBank.Integration.Testing.Fixtures
{
    public class GenericTestContext<T> where T : class
    {

        public HttpClient Client { get; set; }
        private TestServer _server;

        public GenericTestContext()
        {
            SetupClient();
        }

        private void SetupClient()
        {
            _server = new TestServer(new WebHostBuilder()
            .ConfigureAppConfiguration((hostingContext, config) =>
            {
                config
                        .AddJsonFile("C:/DigiEnv/Sharedappsettings.json", optional: true)
                .AddJsonFile("C:/DigiEnv/appsettings.json", optional: true);


                config.AddEnvironmentVariables();
            })
            .UseStartup<T>());
            Client = _server.CreateClient();
        }
    }
}
