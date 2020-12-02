using System.Linq;

namespace AdventOfCode2020.Day2Challenge
{
    public class SledRentalPasswordValidator : IPasswordValidator
    {
        public string PolicyName => "sled rental place down the street";

        public bool IsValid(PasswordRecord record)
        {
            var count = record.Password.Count(x => x == record.Policy.Char);
            return count >= record.Policy.Min && count <= record.Policy.Max;
        }
    }
}