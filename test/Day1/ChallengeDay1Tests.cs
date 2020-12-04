using System.IO;
using AdventOfCode2020;
using DataProvider;
using FluentAssertions;
using Xunit;

namespace ChallengeDay1Tests
{
    public class ChallengeDay1Tests
    {
        [Fact]
        public void Should_Find_The_Product_For_2_Entries_That_Sum_2020()
        {
            var values = new[] { 1721, 979, 366, 299, 675, 1456 };
            var result = MockDayChallenge.FindMultiplicationProductFor2Entries(values, 2020);
            result.Should().Be(514579);
        }

        [Fact]
        public void Should_Find_The_Product_For_3_Entries_That_Sum_2020()
        {
            var values = new[] { 1721, 979, 366, 299, 675, 1456 };
            var result = MockDayChallenge.FindMultiplicationProductFor3Entries(values, 2020);
            result.Should().Be(241861950);
        }

        private class MockDayChallenge : ChallengeDay1
        {
            public MockDayChallenge(IDataProvider<int> dataProvider, TextWriter output)
                : base(dataProvider, output)
            {
            }

            public static int FindMultiplicationProductFor2Entries(int[] values, int sumValue)
            {
                var (value1, value2) = FindEntriesWithSum(values, sumValue);
                return value1 * value2;
            }

            public static int FindMultiplicationProductFor3Entries(int[] values, int sumValue)
            {
                var (value1, value2, value3) = Find3EntriesWithSum(values, sumValue);
                return value1 * value2 * value3;
            }
        }
    }
}
