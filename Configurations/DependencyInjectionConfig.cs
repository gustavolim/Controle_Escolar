using Controle_Escolar.Data.Repository;
using Controle_Escolar.Services;

namespace Controle_Escolar.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped(typeof(IMongoRepository<>), typeof(MongoRepository<>));
            //services
            services.AddScoped<IPessoaService, PessoaService>();
            services.AddScoped<IRecadoService, RecadoService>();


        }
    }
}
