using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Hosting;
using Repository;
using Repository.Service.Models.Repository.Service.Models.Repository.Service;

public class Program
    {
        public static void Main(string[] args)
        {
        CreateHostBuilder(args).Build().Run();
    }
    public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
                .ConfigureWebHostDefaults(webBuilder =>
                {
                    webBuilder.UseStartup<Startup>();
                });
}

    
    

