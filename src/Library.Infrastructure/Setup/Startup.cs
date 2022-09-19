using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace Library.Infrastructure.Setup;

public static class Startup
{
    public static void AddDbContext(this IServiceCollection services, string connectionString) =>
        services.AddDbContext<LibraryContext>(options =>
            options.UseSqlServer(connectionString));
}