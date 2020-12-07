using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text.RegularExpressions;
using AdventOfCode2020.DailyChallenges.Day07;
using FluentAssertions;
using Xunit;
using Xunit.Abstractions;

namespace DailyChallengesTests
{
    public class ChallengeDay7Tests
    {
        private readonly ITestOutputHelper _output;

        public ChallengeDay7Tests(ITestOutputHelper output)
        {
            _output = output;
        }

        [Fact]
        public void Should_Read_All_Rules()
        {
            var rules = BagRuleReader.ReadRules(Data);
            
            rules.Count.Should().Be(9);
        }
        
        [Theory]
        [MemberData(nameof(DataSource))]
        public void Should_Count_How_Many_Bags_Can_Carry(string[] data, int expectedResult)
        {
            var rules = BagRuleReader.ReadRules(data);

            var result = BagRuleReader.HowManyBagsCanCarry("shiny gold", rules);

            result.Should().Be(expectedResult);
        }

        [Fact]
        public void Should_Count_Bags_That_Can_Hold_Shiny_Gold_Bags()
        {
            var rules = BagRuleReader.ReadRules(Data);

            var result = BagRuleReader.CountBagsThatCanHold("shiny gold", rules);
            result.Should().Be(4);
        }

        [Fact]
        public void Should_Test_Something()
        {
            var regex = new Regex(@"^([\s\w]*?)bags contain");

            foreach (var value in Data)
            {
                var match = regex.Match(value);
                foreach (Group matchGroup in match.Groups)
                {
                    _output.WriteLine($"\t{matchGroup.Value}");
                }
            }
        }
        
        [Fact]
        public void Regex_Should_Capture_Colors_Bags_Contained()
        {
            var regex = new Regex(@"(?n)((?<bag>.*) bags contain|((?<capacity>[0-9]{1,2})(?<bag>[\s\w]*) bag))");

            foreach (var value in Data)
            {
                var matches = regex.Matches(value);
                foreach (Match match in matches)
                {
                    foreach (Group matchGroup in match.Groups)
                    {
                        _output.WriteLine($"\tgroup[{matchGroup.Name}]={matchGroup.Value}");
                    }
                }
            }
        }

        
        private static readonly string[] Data = new[]
        {
            "light red bags contain 1 bright white bag, 2 muted yellow bags.",
            "dark orange bags contain 3 bright white bags, 4 muted yellow bags.",
            "bright white bags contain 1 shiny gold bag.",
            "muted yellow bags contain 2 shiny gold bags, 9 faded blue bags.",
            "shiny gold bags contain 1 dark olive bag, 2 vibrant plum bags.",
            "dark olive bags contain 3 faded blue bags, 4 dotted black bags.",
            "vibrant plum bags contain 5 faded blue bags, 6 dotted black bags.",
            "faded blue bags contain no other bags.",
            "dotted black bags contain no other bags.",
        };   
        
        private static readonly string[] Data2 = new[]
        {
            "shiny gold bags contain 2 dark red bags.",
            "dark red bags contain 2 dark orange bags.",
            "dark orange bags contain 2 dark yellow bags.",
            "dark yellow bags contain 2 dark green bags.",
            "dark green bags contain 2 dark blue bags.",
            "dark blue bags contain 2 dark violet bags.",
            "dark violet bags contain no other bags."
        };

        public static IEnumerable<object[]> DataSource = new[]
        {
            new object[] {Data, 32},
            new object[] {Data2, 126}
        };
    }

    //public record Bag
    
}

