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

            services.AddTransient<IDataProvider<int>>(ctx => new DataProvider<int>("data/day{0}_input.txt"));
            services.AddTransient<IDataProvider<string>>(ctx => new DataProvider<string>("data/day{0}_input.txt"));

            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay1>();
            services.AddDay2();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay3>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay4>();
            services.AddTransient<IAdventCodeDayChallenge, ChallengeDay5>();
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