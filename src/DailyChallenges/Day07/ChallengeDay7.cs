﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020.DailyChallenges.Day07
{
    public class ChallengeDay7 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay7(IDataProvider<string> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 7;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            var data = BagRuleReader.ReadRules(_dataProvider.Read(Day));

            ResolvePart1(data);
            ResolvePart2(data);
        }

        private void ResolvePart1(ILookup<string, (int, string)> rules)
        {
            var result = BagRuleReader.CountBagsThatCanHold("shiny gold", rules);
            _output.WriteLine($"\t{result} bag colors can eventually contain at least one shiny gold bag");
        }

        private void ResolvePart2(ILookup<string, (int, string)> rules)
        {
            var result = BagRuleReader.HowManyBagsCanCarry("shiny gold", rules);
            _output.WriteLine($"\tOne shiny gold bag can hold up to {result} bags");
        }
    }


    public static class BagRuleReader
    {
        public static ILookup<string, (int, string)> ReadRules(IEnumerable<string> data)
        {
            return ReadIndividualRules(data).ToLookup(x => x.b, x => (x.q, x.i));
        }

        public static int CountBagsThatCanHold(string bagColor, ILookup<string, (int q, string bc)> rules)
        {
            return WhichBagsThatCanHold(bagColor, rules).Distinct().Count();
        }
        
        public static int HowManyBagsCanCarry(string bagColor, ILookup<string, (int q, string bc)> rules)
        {
            var result = 0;
            var rule = rules.First(x => x.Key == bagColor);
            
            foreach (var coloredBag in rule)
            {
                if (coloredBag.q == 0)
                    continue;
                
                result += coloredBag.q + coloredBag.q * HowManyBagsCanCarry(coloredBag.bc, rules);
            }

            return result;
        }

        public static IEnumerable<string> WhichBagsThatCanHold(string bagColor, ILookup<string, (int q, string bc)> rules)
        {
            foreach (var rule in rules)
            {
                var canHold = rule.Any(x => x.q > 0 && x.bc == bagColor);
                
                // if the color bag can hold the requested bag color,
                // we now count the ones that can also hold this color
                if (canHold)
                {
                    foreach (var bag in WhichBagsThatCanHold(rule.Key, rules))
                    {
                        yield return bag;
                    }
                    yield return rule.Key;
                }
            }
        }

        private static IEnumerable<(string b, int q, string i)> ReadIndividualRules(IEnumerable<string> data)
        {
            const string expression = @"(?n)((?<bag>.*) bags contain|((?<capacity>[0-9]{1,2})(?<bag>[\s\w]*) bag))";
            var regex = new Regex(expression);

            foreach (var value in data)
            {
                var matches = regex.Matches(value);

                string bag = matches[0].Groups["bag"].Value.Trim(' ');

                for (var i = 1; i < matches.Count; i++)
                {
                    yield return (bag, int.Parse(matches[i].Groups["capacity"].Value), matches[i].Groups["bag"].Value.Trim(' '));
                }

                if (matches.Count == 1)
                {
                    yield return (bag, 0, String.Empty);
                }
            }
        }
    }

}