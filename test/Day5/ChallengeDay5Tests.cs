using System.Collections.Generic;
using System.Linq;
using AdventOfCode2020;
using FluentAssertions;
using Xunit;

namespace ChallengeDay5Tests
{
    public class ChallengeDay5Tests
    {
        [Theory]
        [InlineData("FBFBBFFRLR", 44, 5)]
        [InlineData("BFFFBBFRRR",70, 7)]
        [InlineData("FFFBBBFRRR",14, 7)]
        [InlineData("BBFFBBFRLL",102, 4)]
        public void Should_Map_Valid_BoardingPass(string boardingCode, int expetectedRow, int expectedCol)
        {
            var boardingPass = BoardingPassMapper.Map(boardingCode);

            boardingPass.Row.Should().Be(expetectedRow);
            boardingPass.Col.Should().Be(expectedCol);
        }       
        
        [Theory]
        [InlineData(44, 5, 357)]
        [InlineData(70, 7, 567)]
        [InlineData(14, 7, 119)]
        [InlineData(102, 4, 820)]
        public void BoardingPass_Should_Calculate_Id_From_Col_And_Row(int row, int col, int expectedId)
        {
            var boardingPass = new BoardingPass
            {
                Row = row,
                Col = col
            };

            boardingPass.Id.Should().Be(expectedId);
        }
    }
}
