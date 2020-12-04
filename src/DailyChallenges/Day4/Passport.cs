using System.Collections.Generic;
using System.Collections.ObjectModel;

namespace AdventOfCode2020
{
    public class Passport : ReadOnlyDictionary<string, string>
    {
        public Passport(IDictionary<string, string> dictionary) : base(dictionary)
        {
        }

        public static explicit operator Passport(Dictionary<string, string> d) => new(d);
    }
}