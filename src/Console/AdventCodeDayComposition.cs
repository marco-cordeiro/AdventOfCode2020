using AdventOfCode2020.DailyChallenges.Day01;
using AdventOfCode2020.DailyChallenges.Day02;
using AdventOfCode2020.DailyChallenges.Day03;
using AdventOfCode2020.DailyChallenges.Day04;
using AdventOfCode2020.DailyChallenges.Day05;
using AdventOfCode2020.DailyChallenges.Day06;
using AdventOfCode2020.DailyChallenges.Day07;
using AdventOfCode2020.DailyChallenges.Day08;
using AdventOfCode2020.DailyChallenges.Day09;
using AdventOfCode2020.DailyChallenges.Day10;
using AdventOfCode2020.DailyChallenges.Day11;
using AdventOfCode2020.DailyChallenges.Day12;
using AdventOfCode2020.DailyChallenges.Day13;
using AdventOfCode2020.DailyChallenges.Day14;
using AdventOfCode2020.DailyChallenges.Day15;
using AdventOfCode2020.DailyChallenges.Day16;
using AdventOfCode2020.DailyChallenges.Day17;
using AdventOfCode2020.DailyChallenges.Day18;
using AdventOfCode2020.DailyChallenges.Day19;
using AdventOfCode2020.DailyChallenges.Day20;
using AdventOfCode2020.DailyChallenges.Day21;
using AdventOfCode2020.DailyChallenges.Day22;
using AdventOfCode2020.DailyChallenges.Day23;
using AdventOfCode2020.DailyChallenges.Day24;
using AdventOfCode2020.DailyChallenges.Day25;
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

            services.AddTransient<IDataProvider<int>>(ctx => new DataProvider<int>("data/day_{0:D2}_input.txt"));
            services.AddTransient<IDataProvider<string>>(ctx => new DataProvider<string>("data/day_{0:D2}_input.txt"));

            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay1>();
            services.AddDay2();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay3>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay4>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay5>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay6>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay7>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay8>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay9>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay10>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay11>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay12>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay13>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay14>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay15>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay16>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay17>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay18>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay19>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay20>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay21>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay22>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay23>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay24>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay25>();
        }

        public static void AddDay2(this IServiceCollection services)
        {
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay2>();
            services.AddTransient<PasswordValidatorFactory>();
            services.AddTransient<IPasswordValidator, SledRentalPasswordValidator>();
            services.AddTransient<IPasswordValidator, OfficialTobogganCorporatePolicyValidator>();
        }
    }
}