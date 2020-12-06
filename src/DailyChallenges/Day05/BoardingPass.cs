namespace AdventOfCode2020.DailyChallenges.Day05
{
    public record BoardingPass
    {
        public int Row { get; init; }
        public int Col { get; init; }
        public int Id => Row * 8 + Col;
    }
}