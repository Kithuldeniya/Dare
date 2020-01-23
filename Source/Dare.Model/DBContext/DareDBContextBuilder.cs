using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Dare.Model.DBContext
{
    public static class DareDBContextBuilder
    {
        public static void AddDareDbContext(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<DareDBContext>(opts => opts.UseSqlServer(connectionString));
        }
    }
}
