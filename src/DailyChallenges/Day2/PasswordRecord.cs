namespace AdventOfCode2020
{
    public record PasswordRecord
    {
        public PasswordPolicy Policy { get; init; }
    public string Password { get; init; }
}
}