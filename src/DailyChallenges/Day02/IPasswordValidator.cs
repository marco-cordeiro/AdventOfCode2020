namespace AdventOfCode2020.DailyChallenges.Day02
{
    public interface IPasswordValidator
    {
        string PolicyName { get; }

        bool IsValid(PasswordRecord record);
    }
}