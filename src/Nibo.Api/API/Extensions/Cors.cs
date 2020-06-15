using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class Cors
    {
        public static void AddCors(this IServiceCollection services, string policy, string originUrl)
        {
            services.AddCors(o => o.AddPolicy(policy, builder =>
            {
                builder.WithOrigins(originUrl)
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            }));
        }

        public static void AddCors(this IApplicationBuilder app, string policy) =>
            app.UseCors(policy);
    }
}
