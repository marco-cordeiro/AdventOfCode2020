using System;
using System.IO;
using System.Linq;
using Microsoft.Extensions.DependencyInjection;

namespace AdventOfCode2020.Framework
{
    public class AdventCodeDayFactory
    {
        private readonly IServiceProvider _services;
        private readonly TextWriter _output;

        public AdventCodeDayFactory(IServiceProvider services, TextWriter output)
        {
            _services = services;
            _output = output;
        }

        public void Execute(int day)
        {
            var challenge = _services.GetServices<IAdventCodeDayChallenge>().FirstOrDefault(x => x.Day == day);

            if (challenge is null)
            {
                _output.WriteLine($"The Advent of Code challenge for day {day} is not available yet! Come Back Later.");
                return;
            }

            challenge.Execute();
        }
    }
}