using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;

using System;

namespace eBookStore.API.Book
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Console.WriteLine($"eBookStore.API.Book <-> these are my args [{string.Join(",", args)}]");
            CreateHostBuilder(args).Build().Run();
        }

        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
    }
}
