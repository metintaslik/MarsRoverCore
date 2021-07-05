using System;
using MarsRover.Service.Interfaces;
using MarsRover.Service.Repositories;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;

namespace MarsRover.App
{
    class Program
    {
        static void Main(string[] args)
        {
            var serviceProvider = new ServiceCollection()
                .AddLogging()
                .AddScoped<IService, Repository>()
                .BuildServiceProvider();

            var logger = serviceProvider.GetService<ILoggerFactory>()
                .CreateLogger<Program>();
            logger.LogDebug("Start Application");

            var service = serviceProvider.GetService<IService>();
            var vehicles = service.Initialize();

            service.SendCommand(vehicles[0], "LMLMLMLMM");
            Console.WriteLine($"Vehicle1 => {service.CurrentPosition(vehicles[0])}");

            service.SendCommand(vehicles[1], "MMRMMRMRRM");
            Console.WriteLine($"Vehicle2 => {service.CurrentPosition(vehicles[1])}");
        }
    }
}
