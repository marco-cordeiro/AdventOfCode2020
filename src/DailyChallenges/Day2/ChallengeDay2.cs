using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using AdventOfCode2020.Framework;
using DataProvider;

namespace AdventOfCode2020.Day2Challenge
{
    public class ChallengeDay2 : IAdventCodeDayChallenge
    {
        private readonly IDataProvider<string> _dataProvider;
        private readonly PasswordValidatorFactory _validatorFactory;
        private readonly TextWriter _output;

        public ChallengeDay2(IDataProvider<string> dataProvider, PasswordValidatorFactory validatorFactory, TextWriter output)
        {
            _dataProvider = dataProvider;
            _validatorFactory = validatorFactory;
            _output = output;
        }

        public int Day => 2;

        public void Execute()
        {
            _output.WriteLine($"Advent of Code day {Day}");

            ResolvePart1();
            ResolvePart2();
        }

        private void ResolvePart1()
        {
            var data = ReadPasswordRecords();
            var validator = _validatorFactory.GetValidator("Can't remember the policy");
            var validPasswords = data.Count(x => validator.IsValid(x));
            
            _output.WriteLine($"\tFound {validPasswords} valid passwords");
        }

        private void ResolvePart2()
        {
            var data = ReadPasswordRecords();
            var validator = _validatorFactory.GetValidator("Official Toboggan Corporate Policy");
            var validPasswords = data.Count(x => validator.IsValid(x));

            _output.WriteLine($"\tFound {validPasswords} valid passwords using the '{validator.PolicyName}'");
        }

        private IEnumerable<PasswordRecord> ReadPasswordRecords()
        {
            var data = _dataProvider.Read(Day);
            foreach (var value in data)
            {
                PasswordRecord record;
                try
                {
                    record = PasswordRecordMapper.Map(value);
                }
                catch (Exception)
                {
                    _output.WriteLine($"Failed to map '{value}' into a password policy");
                    continue;
                }

                yield return record;
            }
        }
    }
}