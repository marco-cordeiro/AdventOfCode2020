using System.Linq;
using System.Text.RegularExpressions;

namespace AdventOfCode2020.ChallengeDay2
{
    public static class PasswordRecordMapper
    {
        public static PasswordRecord Map(string value)
        {
            const string regexExpression = @"(\d{1,2})-(\d{1,2}) ([a-z]): ([a-z]*)";
            var regex = new Regex(regexExpression);
            var matches = regex.Match(value);

            var min = int.Parse(matches.Groups[1].Value);
            var max = int.Parse(matches.Groups[2].Value);
            var @char = matches.Groups[3].Value.First();
            var pwd = matches.Groups[4].Value;

            return new PasswordRecord
            {
                Policy = new PasswordPolicy
                {
                    Min = min,
                    Max = max,
                    Char = @char
                },
                Password = pwd
            };
        }
    }
}