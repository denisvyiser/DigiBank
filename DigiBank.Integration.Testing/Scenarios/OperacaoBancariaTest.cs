using FluentAssertions;
using System.Net;
using System.Threading.Tasks;
using DigiBank.Integration.Testing.Fixtures;
using Xunit;
using System.Net.Http;
using System.Text;
using System.IO;
using System.Net.Http.Headers;
using Newtonsoft.Json.Linq;

namespace DigiBank.Integration.Testing.Scenarios
{
    public class OperacaoBancariaTest
    {
        private readonly OperacaoBancariaTestContext operacaoContext;
        private readonly LoginTestContext loginContext;

        public OperacaoBancariaTest()
        {
            operacaoContext = new OperacaoBancariaTestContext();
            loginContext = new LoginTestContext();
        }

        [Fact]
        public async Task TransacaoReturnsOkResponse()
        {
            string loginJson = "{\"login\":\"denis\",\"senha\":\"admin\"}";

            HttpContent content = new StringContent(loginJson, Encoding.UTF8, "text/json");


            var loginResponse = await loginContext.Client.PostAsync("/api/v2/Login/Logon", content);

            
            if(loginResponse.StatusCode == HttpStatusCode.OK)
            {
                var retorno = await loginResponse.Content.ReadAsStringAsync();

                JObject o = JObject.Parse(retorno);

                string token = (string)o.SelectToken("tokenKey");

                operacaoContext.Client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token);

                string TransacaoJson = "{\"contaOrigem\":\"12321\",\"contaDestino\":\"12346\",\"valor\": 10.10}";

                content = new StringContent(TransacaoJson, Encoding.UTF8, "text/json");

                var transacaoResponse = await operacaoContext.Client.PostAsync("/api/v2/OperacaoBancaria/Transferencia", content);

                transacaoResponse.EnsureSuccessStatusCode();
                transacaoResponse.StatusCode.Should().Be(HttpStatusCode.OK);
            }

        }

        //[Fact]
        //public async Task Transacao()
        //{
        //    string loginJson = "{\"ContaOrigem\":\"12321\",\"ContaDestino\":\"12346\",\"Valor\":\"10.10\"}";

        //    HttpContent content = new StringContent(loginJson, Encoding.UTF8, "text/json");


        //    var loginResponse = await loginContext.Client.PostAsync("/api/v2/OperacaoBancaria/Transferencia", content);
        //    loginResponse.EnsureSuccessStatusCode();
        //    loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);



        //}

        //[Fact]
        //public async Task ReturnsOkResponse()
        //{
           
        //    var loginResponse = await loginContext.Client.GetAsync("/api/v2/Login");
        //    loginResponse.EnsureSuccessStatusCode();
        //    loginResponse.StatusCode.Should().Be(HttpStatusCode.OK);



        //}
    }
}
