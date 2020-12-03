namespace AdventOfCode2020.ChallengeDay2
{
    public interface IPasswordValidator
    {
        string PolicyName { get; }

        bool IsValid(PasswordRecord record);
    }
}