namespace AdventOfCode2020.DailyChallenges.Day02
{
    public record PasswordRecord
    {
        public PasswordRecord()
    {
        Policy = new PasswordPolicy();
        Password = string.Empty;
    }

    public PasswordPolicy Policy { get; init; }
    public string Password { get; init; }
}
}