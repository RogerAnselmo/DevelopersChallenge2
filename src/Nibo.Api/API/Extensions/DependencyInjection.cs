using API.OfxParser;
using API.Repositories;
using API.Services;
using Microsoft.Extensions.DependencyInjection;

namespace API.Extensions
{
    public static class DependencyInjection
    {
        public static void AddDependencyInjection(this IServiceCollection services)
        {
            services.AddSingleton<OfxDocumentParser>();

            services.AddTransient<OfxService>();
            services.AddTransient<TransactionRepository>();
        }
    }
}
