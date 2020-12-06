using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020.DailyChallenges.Day05
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

            ResolvePart1(boardingPasses);
            ResolvePart2(boardingPasses);
        }

        private void ResolvePart1(IEnumerable<BoardingPass> boardingPasses)
        {
            var highestBoardingPassId = boardingPasses.Max(x => x.Id);
            
            _output.WriteLine($"\tBoarding Pass {highestBoardingPassId} is the highest id");
        }

        private void ResolvePart2(IEnumerable<BoardingPass> boardingPasses)
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
}