using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace Sentry.DemoProject.Web
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args)
        {
            return WebHost.CreateDefaultBuilder(args)
                .UseSentry()
                .UseStartup<Startup>();
        }
    }
}
