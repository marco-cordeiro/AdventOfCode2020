namespace AdventOfCode2020
{
    public interface IPasswordValidator
    {
        string PolicyName { get; }

        bool IsValid(PasswordRecord record);
    }
}