using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020
{
    public class ChallengeDay5 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly TextWriter _output;

        public ChallengeDay5(IDataProvider<string> dataProvider, TextWriter output)
        {
            _dataProvider = dataProvider;
            _output = output;
        }

        public int Day => 5;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            var boardingPasses = _dataProvider.Read(Day).Select(BoardingPassMapper.Map).ToArray();

            var highestBoardingPassId = ResolvePart1(boardingPasses);
            ResolvePart2(boardingPasses, highestBoardingPassId);
        }

        private int ResolvePart1(IEnumerable<BoardingPass> boardingPasses)
        {
            var highestBoardingPassId = boardingPasses.Max(x => x.Id);
            
            _output.WriteLine($"\tBoarding Pass {highestBoardingPassId} is the highest id");
            
            return highestBoardingPassId;
        }

        private void ResolvePart2(IEnumerable<BoardingPass> boardingPasses, int highestBoardingPassId)
        {
            boardingPasses = boardingPasses.OrderBy(x => x.Id);
            var previousBoardingPassId = 0;
            foreach (var boardingPass in boardingPasses)
            {
                if (previousBoardingPassId > 0 && previousBoardingPassId + 2 == boardingPass.Id)
                {
                    _output.WriteLine($"\tYour boarding pass id is {previousBoardingPassId + 1}");
                }
                
                previousBoardingPassId = boardingPass.Id;
            }

            _output.WriteLine($"\tHope you found it");
        }
    }

    public static class BoardingPassMapper
    {
        public static BoardingPass Map(string value)
        {
            var colRangeMax = 7;
            var colRangeMin = 0;
            var rowRangeMax = 127;
            var rowRangeMin = 0;
            foreach (var @char in value)
            {
                switch (@char)
                {
                    case 'F':
                        rowRangeMax = (rowRangeMax - rowRangeMin + 1) / 2 + rowRangeMin - 1;
                        break;
                    case 'B':
                        rowRangeMin = (rowRangeMax - rowRangeMin + 1) / 2 + rowRangeMin;
                        break;
                    case 'L':
                        colRangeMax = (colRangeMax - colRangeMin + 1) / 2 + colRangeMin - 1;
                        break;
                    case 'R':
                        colRangeMin = (colRangeMax - colRangeMin + 1) / 2 + colRangeMin;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException($"'{@char}' is not an acceptable spatial partition character");
                }
            }

            if (rowRangeMax != rowRangeMin || colRangeMax != colRangeMin)
                throw new ArgumentException("Not a valid boarding pass");

            return new BoardingPass
            {
                Row = rowRangeMax,
                Col = colRangeMax
            };
        }
    }

    public record BoardingPass
    {
        public int Row { get; init; }
        public int Col { get; init; }
        public int Id => Row * 8 + Col;
    }
}