using AdventOfCode2020.DailyChallenges.Day02;
using FluentAssertions;
using Xunit;

namespace DailyChallengesTests
{
    public class ChallengeDay2Tests
    {
        [Fact]
        public void Should_Map_PasswordRecord()
        {
            var result = PasswordRecordMapper.Map("1-3 b: cdefg");

            result.Policy.Min.Should().Be(1);
            result.Policy.Max.Should().Be(3);
            result.Policy.Char.Should().Be('b');
            result.Password.Should().Be("cdefg");
        }

        [Fact]
        public void PasswordRecord_Should_Be_Valid_When_Sled_Rental_Policy_Is_Respected()
        {
            var record = new PasswordRecord
            {
                Policy = new PasswordPolicy
                {
                    Min = 1,
                    Max = 3,
                    Char = 'b'
                },
                Password = "cdebbfg"
            };
            var sut = new SledRentalPasswordValidator();

            var result = sut.IsValid(record);

            result.Should().BeTrue();
        }

        [Fact]
        public void PasswordRecord_Should_Be_Invalid_When_Sled_Rental_Policy_Is_Not_Respected()
        {
            var record = new PasswordRecord
            {
                Policy = new PasswordPolicy
                {
                    Min = 1,
                    Max = 3,
                    Char = 'b'
                },
                Password = "cdefg"
            };
            var sut = new SledRentalPasswordValidator();

            var result = sut.IsValid(record);

            result.Should().BeFalse();
        }

        [Fact]
        public void PasswordRecord_Should_Be_Valid_When_Official_Toboggan_Policy_Is_Respected()
        {
            var record = new PasswordRecord
            {
                Policy = new PasswordPolicy
                {
                    Min = 1,
                    Max = 3,
                    Char = 'b'
                },
                Password = "bcdefg"
            };
            var sut = new OfficialTobogganCorporatePolicyValidator();

            var result = sut.IsValid(record);

            result.Should().BeTrue();
        }

        [Fact]
        public void PasswordRecord_Should_Be_Invalid_When_Official_Toboggan_Policy_Is_Not_Respected()
        {
            var record = new PasswordRecord
            {
                Policy = new PasswordPolicy
                {
                    Min = 1,
                    Max = 3,
                    Char = 'b'
                },
                Password = "cdefg"
            };
            var sut = new OfficialTobogganCorporatePolicyValidator();

            var result = sut.IsValid(record);

            result.Should().BeFalse();
        }

        [Theory]
        [InlineData("1-3 a: abcde", true)]
        [InlineData("1-3 b: cdefg", false)]
        [InlineData("2-9 c: ccccccccc", false)]
        public void PasswordRecord_Validate_Using_Official_Toboggan_Policy(string value, bool expectedValid)
        {
            var record = PasswordRecordMapper.Map(value);

            var sut = new OfficialTobogganCorporatePolicyValidator();

            var result = sut.IsValid(record);

            result.Should().Be(expectedValid);
        }

    }
}
