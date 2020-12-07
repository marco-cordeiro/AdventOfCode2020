using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.DailyChallenges.Day07
{
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