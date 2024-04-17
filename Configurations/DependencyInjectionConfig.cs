using Controle_Escolar.Dao;
using Controle_Escolar.Services;

namespace Controle_Escolar.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            //services
            services.AddScoped<IPessoaService, PessoaService>();
            //data
            services.AddScoped<IPessoaDao, PessoaDao>();

        }
    }
}
