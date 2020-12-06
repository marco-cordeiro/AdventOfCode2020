using System.Text.RegularExpressions;

namespace AdventOfCode2020.DailyChallenges.Day04
{
    public static class PassportExtensions
    {
        private static readonly Regex HeightRegex = new Regex("(\\d*)(\\D*)");
        private static readonly Regex HairColorRegex = new Regex("^#[\\da-f]{6}$");
        private static readonly Regex PassportIdRegex = new Regex("^\\d{9}$");
        private static readonly Regex EyeColorRegex = new Regex("amb|blu|brn|gry|grn|hzl|oth");

        public static bool IsValid(this Passport passport, bool strict = false)
        {
            return passport.TryGetValue("byr", out var byr) &&
                   passport.TryGetValue("iyr", out var iyr) &&
                   passport.TryGetValue("eyr", out var eyr) &&
                   passport.TryGetValue("hgt", out var hgt) &&
                   passport.TryGetValue("hcl", out var hcl) &&
                   passport.TryGetValue("ecl", out var ecl) &&
                   passport.TryGetValue("pid", out var pid) &&
                   (!strict ||
                    (
                        ValidateBirthYear(byr) &&
                        ValidateIssueYear(iyr) &&
                        ValidateExpirationYear(eyr) &&
                        ValidateHeight(hgt) &&
                        ValidateHairColor(hcl) &&
                        ValidateEyeColor(ecl) &&
                        ValidatePassportId(pid)
                    ));
        }

        private static bool ValidateBirthYear(string value)
        {
            if (int.TryParse(value, out var year))
                return year >= 1920 && year <= 2002;

            return false;
        }

        private static bool ValidateIssueYear(string value)
        {
            if (int.TryParse(value, out var year))
                return year >= 2010 && year <= 2020;

            return false;
        }

        private static bool ValidateExpirationYear(string value)
        {
            if (int.TryParse(value, out var year))
                return year >= 2020 && year <= 2030;

            return false;
        }

        private static bool ValidateHeight(string value)
        {
            var match = HeightRegex.Match(value);
            if (match.Groups.Count != 3)
                return false;

            if (!int.TryParse(match.Groups[1].Value, out var height))
                return false;

            var unit = match.Groups[2].Value;

            switch (unit)
            {
                case "in":
                    return height >= 59 && height <= 76;
                case "cm":
                    return height >= 150 && height <= 193;
                default:
                    return false;
            }
        }

        private static bool ValidateHairColor(string value)
        {
            return HairColorRegex.IsMatch(value);
        }

        private static bool ValidateEyeColor(string value)
        {
            return EyeColorRegex.IsMatch(value);
        }

        private static bool ValidatePassportId(string value)
        {
            return PassportIdRegex.IsMatch(value);
        }


        //  byr(Birth Year) - four digits; at least 1920 and at most 2002.
        //  iyr(Issue Year) - four digits; at least 2010 and at most 2020.
        //  eyr(Expiration Year) - four digits; at least 2020 and at most 2030.
        //  hgt(Height) - a number followed by either cm or in:
        //      If cm, the number must be at least 150 and at most 193.
        //      If in, the number must be at least 59 and at most 76.
        //  hcl(Hair Color) - a # followed by exactly six characters 0-9 or a-f.
        //  ecl(Eye Color) - exactly one of: amb blu brn gry grn hzl oth.
        //  pid(Passport ID) - a nine-digit number, including leading zeroes.
        //  cid(Country ID) - ignored, missing or not.

    }
}