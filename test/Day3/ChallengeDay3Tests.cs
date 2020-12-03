using System;
using System.IO;
using System.Linq;
using System.Text;
using AdventOfCode2020.ChallengeDay3;
using FluentAssertions;
using Xunit;

namespace ChallengeDay3Tests
{
    public class ChallengeDay3Tests
    {
        [Fact]
        public void Should_Map_ForestMap()
        {
            var values = new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
            var map = ForestMapper.Map(values);
            var sb = new StringBuilder();
            var output = new StringWriter(sb);
            map.PrintMap(output);

            sb.ToString().Should().BeEquivalentTo(string.Join(Environment.NewLine, values));
        }

        [Theory]
        [InlineData(1, 1, 2)]
        [InlineData(3, 1, 7)]
        [InlineData(5, 1, 3)]
        [InlineData(7, 1, 4)]
        [InlineData(1, 2, 2)]
        public void Should_Count_Slope_Trees(int rightSlope, int downSlope, int expectedNumberOfTrees)
        {
            var values = new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
            var map = ForestMapper.Map(values);

            var result = map.CountSlopeTrees(rightSlope, downSlope);

            result.Should().Be(expectedNumberOfTrees);
        }

        [Fact]
        public void Should_Multiple_Slope_Trees()
        {
            var values = new[]
            {
                "..##.......",
                "#...#...#..",
                ".#....#..#.",
                "..#.#...#.#",
                ".#...##..#.",
                "..#.##.....",
                ".#.#.#....#",
                ".#........#",
                "#.##...#...",
                "#...##....#",
                ".#..#...#.#"
            };
            var map = ForestMapper.Map(values);
            var slopes = new (int r, int d)[]
            {
                (1, 1),
                (3, 1),
                (5, 1),
                (7, 1),
                (1, 2),
            };

            var result = slopes.Select(x => map.CountSlopeTrees(x.r, x.d)).Aggregate((a, b) => a * b);

            result.Should().Be(336);
        }
    }
}
