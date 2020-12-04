namespace AdventOfCode2020
{
    public class OfficialTobogganCorporatePolicyValidator : IPasswordValidator
    {
        public string PolicyName => "Official Toboggan Corporate Policy";

        public bool IsValid(PasswordRecord record)
        {
            return record.Password.Length >= record.Policy.Max &&
                   ((record.Password[record.Policy.Min - 1] == record.Policy.Char &&
                     record.Password[record.Policy.Max - 1] != record.Policy.Char) ||
                    (record.Password[record.Policy.Min - 1] != record.Policy.Char &&
                     record.Password[record.Policy.Max - 1] == record.Policy.Char));
        }
    }
}