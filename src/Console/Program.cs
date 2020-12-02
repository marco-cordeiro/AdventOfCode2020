using System;
using AdventOfCode2020.Framework;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2020.Console
{
    class Program
    {
        static void Main(string[] args)
        {
            var services = CreateServices();

            var adventFactory = services.GetRequiredService<AdventCodeDayFactory>();

            if (args.Length == 1)
            {
                var day = int.Parse(args[0]);
                adventFactory.Execute(day);
                return;
            }

            for (int i = 1; i < 26; i++)
            {
                adventFactory.Execute(i);
            }
        }

        private static IServiceProvider CreateServices()
        {
            var services = new ServiceCollection();
            services.Register();
            return services.BuildServiceProvider();
        }
    }
}
