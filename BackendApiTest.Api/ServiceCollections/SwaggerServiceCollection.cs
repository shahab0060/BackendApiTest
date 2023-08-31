using Microsoft.OpenApi.Models;
using System.Reflection;

namespace BackendApiTest.Api.ServiceCollections
{
    public static class SwaggerServiceCollection
    {
        public static void AddSwaggerUi(this WebApplication application, string urlPrefix = "")
        {
            application.UseSwagger();
            application.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/base/swagger.json", "سرویس پایه");
                c.InjectStylesheet("/swagger/ui/custom.css");

            });
        }

        public static void AddSwagger(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.CustomSchemaIds(a =>
                     a.FullName
                );
                c.SwaggerDoc("base", new OpenApiInfo { Title = "سرویس پایه", Version = "base", Description = "api های جنرال و مشترک در تمامی زیر سیستم ها در این بخش قرار دارند" });


            });
        }


    }





}