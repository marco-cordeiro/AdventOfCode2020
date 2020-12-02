namespace AdventOfCode2020.Day2Challenge
{
    public record PasswordRecord
    {
        public PasswordPolicy Policy { get; init; }
        public string Password { get; init; }
    }
}