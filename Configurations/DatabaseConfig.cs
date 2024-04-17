using Controle_Escolar.Data.Context;

namespace Controle_Escolar.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.AddScoped<IPessoaDbContext>(_ => new PessoaDbContext(configuration.GetConnectionString("MongoDbControleEscolar")));

        }
    }
}
