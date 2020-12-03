namespace AdventOfCode2020.ChallengeDay2
{
    public record PasswordRecord
    {
        public PasswordPolicy Policy { get; init; }
    public string Password { get; init; }
}
}