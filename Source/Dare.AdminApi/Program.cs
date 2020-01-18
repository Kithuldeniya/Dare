using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Serilog;
using Serilog.Context;
using Serilog.Events;
using System;
using System.IO;

namespace Dare.AdminApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            ConfigLogging();

            Log.Information("No contextual properties");

            try
            {
                Log.Information("Getting the motors running...");

                CreateHostBuilder(args).Build().Run();
                return;
            }
            catch (Exception ex)
            {
                Log.Fatal(ex, "Host terminated unexpectedly");
                return;
            }
            finally
            {
                Log.Information("Getting the motors finally...");
                Log.CloseAndFlush();
            }

        }


        public static IHostBuilder CreateHostBuilder(string[] args) =>
            Host.CreateDefaultBuilder(args)
            .ConfigureWebHostDefaults(webBuilder =>
            {
                webBuilder.UseStartup<Startup>();
            })
            .UseSerilog();


        private static void ConfigLogging()
        {
            //var configFilePath = $".{Path.DirectorySeparatorChar}appsettings.json";
            var environment = Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT");
            
            var configuration = new ConfigurationBuilder()
            .AddJsonFile("appsettings.json", false, true)
            .AddJsonFile($"appsettings.{environment}.json", true, true)
            .AddEnvironmentVariables()
            .Build();

            Log.Logger = new LoggerConfiguration()
                .ReadFrom.Configuration(configuration)
                .CreateLogger();
          
        }
    }
}
