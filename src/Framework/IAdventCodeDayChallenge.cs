namespace AdventOfCode2020.Framework
{
    public interface IAdventCodeDayChallenge
    {
        int Day { get; }

        void Execute();
    }
}