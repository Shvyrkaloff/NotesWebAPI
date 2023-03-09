using NotesPresistence;

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

