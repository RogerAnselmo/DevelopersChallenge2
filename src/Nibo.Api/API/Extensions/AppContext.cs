using API.Repositories.Context;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.EntityFrameworkCore;

namespace API.Extensions
{
    public static class AppContext
    {
        public static void AddNiboContext(this IServiceCollection services, string connectionString) =>
            services.AddDbContext<NiboContext>(x =>
                x.UseSqlServer(connectionString));
    }
}
