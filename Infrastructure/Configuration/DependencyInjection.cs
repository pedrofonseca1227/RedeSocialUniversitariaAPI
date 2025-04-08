using RedeSocialUniversitaria.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using RedeSocialUniversitaria.Infrastructure.Context;
using RedeSocialUniversitaria.Infrastructure.Repositories;

namespace RedeSocialUniversitaria.Infrastructure.Configuration
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            services.AddScoped<IPostagemRepository, PostagemRepository>();
            services.AddScoped<IEventoRepository, EventoRepository>();

            return services;
        }
    }
}
