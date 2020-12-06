using System;

namespace AdventOfCode2020
{
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
}