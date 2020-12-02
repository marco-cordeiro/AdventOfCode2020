namespace AdventOfCode2020.Day2Challenge
{
    public interface IPasswordValidator
    {
        string PolicyName { get; }

        bool IsValid(PasswordRecord record);
    }
}