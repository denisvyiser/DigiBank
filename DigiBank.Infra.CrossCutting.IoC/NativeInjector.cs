using AutoMapper;
using DigiBank.Application.AutoMapper;
using DigiBank.Application.Interfaces;
using DigiBank.Application.Services;
using DigiBank.Domain.Interfaces;
using DigiBank.Infra.CrossCutting.Identity.Interfaces;
using DigiBank.Infra.CrossCutting.Identity.Services;
using DigiBank.Infra.CrossCutting.Utilities;
using DigiBank.Infra.Data.Context;
using DigiBank.Infra.Data.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;


namespace DigiBank.Infra.CrossCutting.IoC
{
    public class NativeInjector
    {
        public static void RegisterServices(IServiceCollection services)
        {
            //Nuget: Microsoft.AspNetCore.Http
            // ASP.NET HttpContext dependency
            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();

            // Domain Bus (Mediator)
            //services.AddScoped<IMediatorHandler, InMemoryBus>();

            // ASP.NET Authorization Polices
            //services.AddSingleton<IAuthorizationHandler, ClaimsRequirementHandler>();

            // Application
            services.AddScoped<IClienteAppService, ClienteAppService>();
            services.AddScoped<IClientePerfilAppService, ClientePerfilAppService>();
            services.AddScoped<IContaCorrenteAppService, ContaCorrenteAppService>();
            services.AddScoped(typeof(IGenericAppService<,>), typeof(GenericAppService <,>));
            services.AddScoped<IPerfilAppService, PerfilAppService>();
            services.AddScoped<ITokenAppService, TokenAppService>();
            services.AddScoped<ITransacaoAppService, TransacaoAppService>();
            services.AddScoped<ILoginAppService, LoginAppService>();
            services.AddScoped<IOperacaoBancariaAppService, OperacaoBancariaAppService>();

            // Infra - Data
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            services.AddScoped<IClienteRepository, ClienteRepository>();
            services.AddScoped<IClientePerfilRepository, ClientePerfilRepository>();
            services.AddScoped<IContaCorrenteRepository, ContaCorrenteRepository>();
            services.AddScoped<IPerfilRepository, PerfilRepository>();
            services.AddScoped<ITokenRepository, TokenRepository>();
            services.AddScoped<ITransacaoRepository, TransacaoRepository>();
            services.AddScoped<DigiBankContext>();
            
            // Infra - Data CrossCutting Utilities
            
            services.AddTransient(typeof(Response<>));
            services.AddScoped<TokenContextAccessor>();


            // Infra - Identity Services
            services.AddScoped<IEmailSender, EmailSender>();

            IMapper mapper = AutoMapperConfig.RegisterMappings().CreateMapper();
            services.AddSingleton(mapper);


        }
    }
}