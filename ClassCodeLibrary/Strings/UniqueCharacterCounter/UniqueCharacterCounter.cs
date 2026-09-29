namespace ClassCodeLibrary.Strings.UniqueCharacterCounter;

/// <summary>
/// Counts character occurrences in a string. Pure functions: no console output.
/// </summary>
public static class UniqueCharacterCounter
{
    /// <summary>
    /// Counts each character manually with a single pass (no LINQ).
    /// </summary>
    /// <param name="input">The string to analyze.</param>
    /// <returns>Character-to-count mapping in first-seen order.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static IReadOnlyDictionary<char, int> CountUniqueCharacters(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var counts = new Dictionary<char, int>();
        foreach (char c in input)
        {
            counts[c] = counts.TryGetValue(c, out int existing) ? existing + 1 : 1;
        }

        return counts;
    }

    /// <summary>
    /// Counts each character using LINQ grouping.
    /// </summary>
    /// <param name="input">The string to analyze.</param>
    /// <returns>Character-to-count mapping.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static IReadOnlyDictionary<char, int> CountUniqueCharactersLinq(string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return input.GroupBy(c => c).ToDictionary(g => g.Key, g => g.Count());
    }
}
