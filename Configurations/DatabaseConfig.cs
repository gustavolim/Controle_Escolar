using Controle_Escolar.Data.Context;
using Microsoft.Extensions.Options;

namespace Controle_Escolar.Configurations
{
    public static class DatabaseConfig
    {
        public static void AddDatabaseConfiguration(this IServiceCollection services, IConfiguration configuration)
        {
            if (services == null) throw new ArgumentNullException(nameof(services));

            services.Configure<MongoDbSettings>(configuration.GetSection("MongoDbSettings"));

            services.AddSingleton<IMongoDbSettings>(serviceProvider =>
                serviceProvider.GetRequiredService<IOptions<MongoDbSettings>>().Value);

            //services.AddScoped<IPessoaDbContext>(_ => new PessoaDbContext(configuration.GetConnectionString("MongoDbControleEscolar")));

        }
    }
}
