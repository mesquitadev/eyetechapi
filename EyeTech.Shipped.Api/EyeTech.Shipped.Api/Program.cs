using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;

namespace EyeTech.Shipped.Api
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateWebHostBuilder(args).Build().Run();
        }

        public static IWebHostBuilder CreateWebHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseUrls("http://*:5000")
                ////.UseSetting("https_port", "8085")
                .UseStartup<Startup>();
    }
}
