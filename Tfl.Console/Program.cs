using Microsoft.Extensions.DependencyInjection;
using Tfl.Road.AppServices.Repositories;
using Tfl.Road.AppServices.Services;
using System;
using Microsoft.Extensions.Configuration;

namespace Tfl.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                throw new NotImplementedException("You should just enter one argument");
            }

            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appSettings.json");

            IConfiguration config = builder.Build();

            var serviceProvider = ConfigureServices(config);

            Run(serviceProvider, args[0]);
        }

        private static void Run(IServiceProvider serviceProvider, string road)
        {
            var roadService = serviceProvider.GetService<IRoadService>();
            var formatter = serviceProvider.GetService<IOutputFormatter>();

            if (roadService == null || formatter == null)
            {
                throw new NullReferenceException("You need to register services correctly");
            }

            var output = formatter.Format(roadService.GetByRoad(road));

            System.Console.WriteLine(output.OutputText);
            Environment.ExitCode = output.ExitCode;
        }

        private static IServiceProvider ConfigureServices(IConfiguration config)
        {
            var serviceProvider = new ServiceCollection()
                .AddSingleton<IRoadService, RoadService>()
                .AddSingleton<IRoadRepository, RoadRepository>()
                .AddSingleton<IOutputFormatter, OutputFormatter>()
                .AddSingleton(config)
                .AddHttpClient()
                .BuildServiceProvider();

            return serviceProvider;
        }
    }
}
