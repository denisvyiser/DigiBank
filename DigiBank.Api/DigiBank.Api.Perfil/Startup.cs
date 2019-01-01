using System;
using DigiBank.Infra.CrossCutting.Identity.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Newtonsoft.Json.Serialization;
using Swashbuckle.AspNetCore.Swagger;
using DigiBank.Infra.CrossCutting.IoC;

namespace DigiBank.Api.Perfil
{
    public class Startup
    {

        private readonly ILoggerFactory loggerFactory;
        public IConfiguration Configuration { get; }
        public Startup(IConfiguration configuration) => Configuration = configuration;

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                 .AddJsonOptions(o =>
                 {
                     o.SerializerSettings.ContractResolver = new CamelCasePropertyNamesContractResolver();
                     //  o.SerializerSettings.NullValueHandling = NullValueHandling.Ignore;
                 });

            var signingConfigurations = new SigningConfigurations(Configuration);
            services.AddSingleton(signingConfigurations);

            var tokenConfigurations = new TokenConfigurations();
            new ConfigureFromConfigurationOptions<TokenConfigurations>(
                Configuration.GetSection("TokenConfigurations"))
                    .Configure(tokenConfigurations);

            services.AddSingleton(tokenConfigurations);


            services.AddAuthentication(authOptions =>
            {
                authOptions.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                authOptions.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(bearerOptions =>
            {
                var paramsValidation = bearerOptions.TokenValidationParameters;

                bearerOptions.SaveToken = true;
                paramsValidation.IssuerSigningKey = signingConfigurations.Key;
                paramsValidation.ValidAudience = tokenConfigurations.Audience;
                paramsValidation.ValidIssuer = tokenConfigurations.Issuer;

                // Valida a assinatura de um token recebido
                paramsValidation.ValidateIssuerSigningKey = true;

                // Verifica se um token recebido ainda é válido
                paramsValidation.ValidateLifetime = true;

                // Tempo de tolerância para a expiração de um token (utilizado
                // caso haja problemas de sincronismo de horário entre diferentes
                // computadores envolvidos no processo de comunicação)
                paramsValidation.ClockSkew = TimeSpan.Zero;
            });



            // Ativa o uso do token como forma de autorizar o acesso
            // a recursos deste projeto
            services.AddAuthorization(auth =>
            {
                auth.AddPolicy("DigiBank", new AuthorizationPolicyBuilder()
                    .AddAuthenticationSchemes(JwtBearerDefaults.AuthenticationScheme‌​)
                    .RequireAuthenticatedUser().Build());
            });


            //Nuget
            //    {
            //    "Microsoft.AspNetCore.Mvc.Versioning"
            //}
            services.AddApiVersioning(options =>
            {
                options.AssumeDefaultVersionWhenUnspecified = true;
                options.ApiVersionReader = new MediaTypeApiVersionReader();
                options.ApiVersionSelector = new CurrentImplementationApiVersionSelector(options);
            });



            //Nuget
            //    {
            //    "Swashbuckle.AspNetCore"
            //}

            services.AddSwaggerGen(s =>
            {
                s.SwaggerDoc(Configuration.GetValue<string>("Application:Version"), new Info
                {
                    Version = Configuration.GetValue<string>("Application:Version"),
                    Title = "DigiBank",
                    Description = "API de interface",
                    Contact = new Contact { Name = "DigiBank", Email = "DigiBank@DigiBank.com.br", Url = "http://www.DigiBank.com.br" },
                    License = new License { Name = "Digi", Url = "https://localhost/api/v1/LICENSE" }
                });
            });

            //Inicialização de Perfis de mapeamento


            //var mappingConfig = new MapperConfiguration(mc =>
            //{
            //    mc.AddProfile(new TipoCriterioProfile());
            //});

            //IMapper mapper = mappingConfig.CreateMapper();
            //services.AddSingleton(mapper);

            RegisterServices(services);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            app.UseStatusCodePages(async context =>
            {
                if (context.HttpContext.Request.Path.StartsWithSegments("/api") &&
                   (context.HttpContext.Response.StatusCode == 401 ||
                    context.HttpContext.Response.StatusCode == 403))
                {
                    await context.HttpContext.Response.WriteAsync("Requisição não Autorizada. Token Expirado!");
                }
            });

            //var builder = new ConfigurationBuilder()
            //.SetBasePath(env.ContentRootPath)
            //.AddJsonFile("C:/Env/appsettings.json", optional: true, reloadOnChange: true);

            //Nuget
            //    {
            //    "Serilog.Extensions.Logging.File"
            //}


            loggerFactory.AddConsole(Configuration.GetSection("Logging"));
            loggerFactory.AddDebug();
            loggerFactory.AddFile(Configuration.GetValue<string>("LogsDirectory") + "ERROR-{Date}.txt", LogLevel.Error);
            loggerFactory.AddFile(Configuration.GetValue<string>("LogsDirectory") + "WARNING-{Date}.txt", LogLevel.Warning);
            loggerFactory.AddFile(Configuration.GetValue<string>("LogsDirectory") + "INFO-{Date}.txt");

            //loggerFactory.AddFile("ERROR-{Date}.txt", LogLevel.Error);
            //loggerFactory.AddFile("WARNING-{Date}.txt", LogLevel.Warning);
            //loggerFactory.AddFile("INFO-{Date}.txt", LogLevel.Information);


            // Configuration = builder.Build();

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            string version = string.Format("/swagger/{0}/swagger.json", Configuration.GetValue<string>("Application:Version"));
            string versionDescription = string.Format("APi DigiBank versão: {0}", Configuration.GetValue<string>("Application:VersionDescription"));


            app.UseSwagger();
            app.UseSwaggerUI(s =>
            {
                s.SwaggerEndpoint(version, versionDescription);
            });

            //app.UseHttpsRedirection();
            app.UseMvc();
        }

        private static void RegisterServices(IServiceCollection services)
        {
            // Adding dependencies from another layers (isolated from Presentation)
            NativeInjector.RegisterServices(services);
        }
    }
}
