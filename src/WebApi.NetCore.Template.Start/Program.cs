using System;
using System.IO;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Serilog;

namespace WebApi.NetCore.Template.Start
{
    public class Program
    {
        public static void Main(string[] args)
        {
            IConfiguration loggerConfig = new ConfigurationBuilder()
                .AddJsonFile($"{Startup.ConfigFolder}/appsettings.json", optional: false)
                .AddJsonFile($"{Startup.ConfigFolder}/appsettings.Development.json", optional: true)
                .AddEnvironmentVariables()
                .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(loggerConfig)
                .CreateLogger();
            
            Serilog.Debugging.SelfLog.Enable(Console.WriteLine);

            try
            {
                CreateHostBuilder(args).Build().Run();
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
            }
            finally
            {
                Log.CloseAndFlush();
            }
        }

        public static IWebHostBuilder CreateHostBuilder(string[] args) =>
            WebHost.CreateDefaultBuilder(args)
                .UseStartup<Startup>()
                .UseContentRoot(Directory.GetCurrentDirectory())
                .UseSerilog();
    }
}