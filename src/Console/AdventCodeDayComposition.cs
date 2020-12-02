﻿using AdventOfCode2020.Day1;
using AdventOfCode2020.Framework;
using DataProvider;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2020.Console
{
    internal static class AdventCodeDayComposition
    {
        public static void Register(this IServiceCollection services)
        {
            services.AddTransient<AdventCodeDayFactory>();

            services.AddSingleton(x => System.Console.In);
            services.AddSingleton(x => System.Console.Out);

            services.AddTransient<IDataProvider<int>>(ctx => new DataProvider<int>("day{0}_input.txt"));
            services.AddTransient<IDataProvider<string>>(ctx => new DataProvider<string>("day{0}_input.txt"));
            
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay1>();
        }
    }
}