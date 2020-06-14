using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.OpenApi.Models;

namespace API.Extensions
{
    public static class Swagger
    {
        public static void AddSwagger(this IServiceCollection services) =>
            services.AddSwaggerGen(x => x.SwaggerDoc("v1",
                new OpenApiInfo
                {
                    Title = "Nibo Api",
                    Version = "1.0"
                }));

        public static void AddSwagger(this IApplicationBuilder app)
        {
            app.UseSwagger();

            app.UseSwaggerUI(c =>
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "Nibo"));

        }
    }
}
