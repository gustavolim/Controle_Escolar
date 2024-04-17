using Controle_Escolar.Middlewares;
using Microsoft.OpenApi.Models;
using System.Reflection;

namespace Controle_Escolar.Configurations
{
    public static class SwaggerConfig
    {
        public static void AddSwaggerConfiguration(this IServiceCollection services)

        {

            if (services == null) throw new ArgumentNullException(nameof(services));



            services.AddSwaggerGen(s =>

            {

                s.OperationFilter<SwaggerDefaultValues>();

                s.UseAllOfToExtendReferenceSchemas();

                s.SwaggerDoc("v1.ControleEscolar", new OpenApiInfo

                {

                    Title = "API de dados do Controle Escolar",

                    Version = "v1",

                    Description = "Endpoints dedicados a dados de Controle Escolar",


                });



                //var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";

                //var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);

                //s.IncludeXmlComments(xmlPath);

            });

        }



        public static void UseSwaggerSetup(this IApplicationBuilder app)

        {

            if (app == null) throw new ArgumentNullException(nameof(app));



            app.UseSwagger(c => { c.RouteTemplate = "doc/{documentName}/swagger.json"; c.SerializeAsV2 = true; });

            app.UseSwaggerUI(c =>

            {

                c.RoutePrefix = "doc";

                c.SwaggerEndpoint("./v1.ControleEscolar/swagger.json", "Controle Escolar V1");

            });

        }

    }
}