﻿namespace AdventOfCode2020.DailyChallenges.Day02
{
    public record PasswordPolicy
    {
        public int Min { get; init; }
    public int Max { get; init; }
    public char Char { get; init; }
}
}