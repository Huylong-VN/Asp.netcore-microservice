using Microsoft.EntityFrameworkCore;

namespace Product.API.Extentions
{
    public static class HostExtentions
    {
        public static IHost MigrationDataBase<TContext>(this IHost host, Action<TContext, IServiceProvider> seeder)
            where TContext : DbContext
        {
            using(var scope = host.Services.CreateScope())
            {
                var service = scope.ServiceProvider;
                var logger = service.GetRequiredService<ILogger<TContext>>();
                var context = service.GetService<TContext>();

                try
                {
                    logger.LogInformation("Migrating mysql database");
                    context.Database.Migrate();
                    logger.LogInformation("Migrated mysql database.");
                    InvokeSeeder(seeder,context,service);
                }
                catch(Exception ex)
                {
                    logger.LogError(ex, "An error occurred while migrating the mysql database");
                }
            }
            return host;
        }

        private static void InvokeSeeder<TContext>(Action<TContext,IServiceProvider> seeder, TContext context,
            IServiceProvider services)
            where TContext : DbContext
        {
            seeder(context,services);
        }
    }
}
