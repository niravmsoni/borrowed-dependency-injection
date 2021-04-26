using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

namespace DependencyInjection
{
    public class Program
    {
        public static void Main(string[] args)
        {
            CreateHostBuilder(args)//creates
                .Build()//builds
                .Run();//and runs
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
