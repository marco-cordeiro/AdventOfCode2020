using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.DailyChallenges.Day04
{
    public static class PassportReader
    {
        public static IEnumerable<Passport> ReadPassports(IEnumerable<string> data)
        {
            var passport = new Dictionary<string, string>();
            foreach (var field in StreamFields(data))
            {
                if (string.IsNullOrWhiteSpace(field))
                {
                    // return the filled password
                    yield return (Passport)passport;
                    //we start a blank passport at this
                    passport = new Dictionary<string, string>();

                    continue;
                }

                var parts = field.Split(':');
                passport[parts[0]] = parts[1];
            }

            // if the last passport was not returned yet
            if (passport.Any())
                yield return (Passport)passport;
        }

        private static IEnumerable<string> StreamFields(IEnumerable<string> data)
        {
            foreach (var line in data)
            {
                var fields = line.Split(' ');
                foreach (var field in fields)
                {
                    yield return field;
                }
            }
        }
    }
}