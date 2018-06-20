using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System;
using ysamedia.Data;
using ysamedia.Models;

namespace ysamedia
{
    public class Program
    {
        public static void Main(string[] args)
        {           
            var host = BuildWebHost(args);

            using (var scope = host.Services.CreateScope())
            {
                var services = scope.ServiceProvider;                               
                try
                {
                    // For seeding Identity tables in ApplicationDbContext 
                    //var context = services.GetRequiredService<ApplicationDbContext>();
                    //UserRoleSeed.InitializeAsync(context, services).Wait();
                    var context = services.GetRequiredService<ApplicationDbContext>();
                    DbInitializer.InitializeAsync(context, services).Wait();

                    /************* Seeds All The Relevant Non-Asp.Net Identity Tables **************/
                    //DbInitializer.Initialize(services);
                }
                catch(Exception ex)
                {
                    var logger = services.GetRequiredService<ILogger<Program>>();
                    logger.LogError(ex, "An Error Occured While Seeding The Database.");
                }                               
            }
            host.Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .Build();
    }
}
