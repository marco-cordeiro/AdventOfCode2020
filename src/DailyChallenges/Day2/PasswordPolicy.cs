namespace AdventOfCode2020.ChallengeDay2
{
    public record PasswordPolicy
    {
        public int Min { get; init; }
    public int Max { get; init; }
    public char Char { get; init; }
}
}