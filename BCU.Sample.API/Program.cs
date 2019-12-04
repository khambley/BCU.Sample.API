using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;

namespace BCU.Sample.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            BuildWebHost(args).Run();
        }

        public static IWebHost BuildWebHost(string[] args) =>
            //WebHost.CreateDefaultBuilder(args)
            //instead of hiding the default configuration for the web host, we are explicitly defining it here.
            new WebHostBuilder()
                .UseKestrel() //a new cross-platform web server
                .UseContentRoot(Directory.GetCurrentDirectory())
                .ConfigureAppConfiguration(config =>
                    config.AddJsonFile("appSettings.json", true)
                )
                .ConfigureLogging(logging => // log console and debug output
                    logging
                        .AddConsole()
                        .AddDebug()
                )
                .UseIISIntegration() //run on IIS if it is available
                .UseStartup<Startup>()

                .Build();
    }
}
