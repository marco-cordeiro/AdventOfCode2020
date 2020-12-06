using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020;
using FluentAssertions;
using Xunit;

namespace ChallengeDay6Tests
{
    public class ChallengeDay6Tests
    {
        [Fact]
        public void Should_Count_All_Answers_For_All_Groups()
        {

            var result = GroupAnswersReader.CountAllAnswersForGroups(_data).ToArray();

            result.Should().HaveCount(5);
            result.Should().BeEquivalentTo(new[] {3, 3, 3, 1, 1});
        }     
        
        [Fact]
        public void Should_Count_All_Common_Answers_For_All_Groups()
        {

            var result = GroupAnswersReader.CountAllSameAnswersForGroups(_data).ToArray();

            result.Should().HaveCount(5);
            result.Should().BeEquivalentTo(new[] {3, 0, 1, 1, 1});
        }

        private readonly IEnumerable<string> _data = new[]
        {
            "abc",
            "",
            "a",
            "b",
            "c",
            "",
            "ab",
            "ac",
            "",
            "a",
            "a",
            "a",
            "a",
            "",
            "b"
        };
    }
}
