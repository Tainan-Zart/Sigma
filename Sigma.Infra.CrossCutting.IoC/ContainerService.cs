using System.Reflection;
using System.Text;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Sigma.Application.Interfaces;
using Sigma.Application.Services;
using Sigma.Domain.Interfaces.Infra.Auth;
using Sigma.Domain.Interfaces.Repositories;
using Sigma.Infra.CrossCutting.Auth;
using Sigma.Infra.Data.Context;
using Sigma.Infra.Data.Repositories;


namespace Sigma.Infra.CrossCutting.IoC
{

    public static class ContainerService
    {
        public static IServiceCollection AddApplicationServicesCollentions(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IAuthToken, AuthToken>();
            services.AddServices();
            services.AddRepositories();
            services.AddAuthentication(configuration);
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IProjetoService, ProjetoService>();
            services.AddScoped<IAutenticacaoService, AutenticacaoService>();
            services.AddScoped<IUsuarioService, UsuarioService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IProjetoRepository, ProjetoRepository>();
            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            services.AddFluentValidationAutoValidation();
            services.AddValidatorsFromAssembly(Assembly.Load("Sigma.Application"));
            return services;
        }


        public static IServiceCollection AddAuthentication(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthentication(options => 
                {
                    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration.GetValue<string>("Jwt:Private-Key"))),
                        ClockSkew = TimeSpan.Zero
                    };
                });

            return services;
        }

        public static IServiceCollection AddApplicationContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<SigmaContext>(options => options.UseNpgsql(connectionString, b => b.MigrationsAssembly("Sigma.Infra.Data")));
            return services;
        }


    }
}
