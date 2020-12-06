using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020
{
    public static class GroupAnswersReader
    {
        public static IEnumerable<int> CountAllSameAnswersForGroups(IEnumerable<string> data)
        {
            var passport = new List<int>();
            foreach (var groupAnswers in StreamAnswersPerGroup(data))
            {
                IEnumerable<char>? commonAnswers = null;
                foreach (var answers in groupAnswers)
                {
                    if (commonAnswers is null)
                    {
                        commonAnswers = answers.Select(x => x);
                        continue;
                    }

                    commonAnswers = commonAnswers.Intersect(answers);
                }

                yield return commonAnswers?.Count() ?? 0;
            }
        }       
        
        public static IEnumerable<int> CountAllAnswersForGroups(IEnumerable<string> data)
        {
            var passport = new List<int>();
            foreach (var groupAnswers in StreamAnswersPerGroup(data))
            {
                var answers = StreamGroupAnswers(groupAnswers);

                yield return answers.Distinct().Count();
            }
        }

        private static IEnumerable<char> StreamGroupAnswers(IEnumerable<string> data)
        {
            foreach (var line in data)
            {
                // returns all answers
                foreach (var @char in line)
                {
                    // ignores end of line characters
                    if (@char >= 'a' && @char <= 'z')
                        yield return @char;
                }
            }
        }
        private static IEnumerable<IEnumerable<string>> StreamAnswersPerGroup(IEnumerable<string> data)
        {
            var answers = new List<string>();
            
            foreach (var line in data)
            {
                // an empty line means that the group is over
                if (string.IsNullOrWhiteSpace(line))
                {
                    yield return answers;
                    answers = new List<string>();
                    continue;
                }

                answers.Add(line);
            }
            
            // just check if there is still a group answers in the buffer
            if (answers.Count > 0)
                yield return answers;
        }
    }
}