using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using NotesPresistence;
using NotesApplication;

namespace NotesWebApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
           var host = CreateHostBuilder(args).Build();
           host.Run();

           using (var scope = host.Services.CreateScope())
           {
                var serviceProvider = scope.ServiceProvider;
                try
                {
                    var conntext = serviceProvider.GetRequiredService<NotesDbContext>();
                    DbInitializer.Initialize(conntext);
                }
                catch (Exception ex)
                {

                }
           }
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args).ConfigureWebHostDefaults(webBuider =>
            {
                webBuider.UseStartup<Startup>();
            });
    }
}

