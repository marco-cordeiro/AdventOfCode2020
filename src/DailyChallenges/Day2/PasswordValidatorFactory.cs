using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2020.ChallengeDay2
{
    public class PasswordValidatorFactory : GenericNamedFactory<IPasswordValidator>
    {
        public PasswordValidatorFactory(IEnumerable<IPasswordValidator> validators)
            : base(validators, x => x.PolicyName, "sled rental place down the street")
        {
        }
    }

    public class GenericNamedFactory<T>
    {
        private readonly string _defaultInstanceName;
        private readonly IDictionary<string, T> _validators;

        public GenericNamedFactory(IEnumerable<T> validators, Func<T, string> getInstanceName, string defaultInstanceName = "default")
        {
            _defaultInstanceName = defaultInstanceName;
            _validators = validators.ToDictionary(getInstanceName);

            if (!_validators.ContainsKey(defaultInstanceName))
                throw new ArgumentOutOfRangeException($"Default instance named '{defaultInstanceName}' not found");
        }

        public T GetValidator(string instanceName)
        {
            return _validators.TryGetValue(instanceName, out var policy) ?
                policy :
                _validators[_defaultInstanceName];
        }
    }
}