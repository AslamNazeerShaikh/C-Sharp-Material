namespace ClassCodeLibrary.Strings.StringDuplicationFiltering;

/// <summary>
/// LINQ counterparts for string filtering. Pure functions: no console output.
/// </summary>
public static partial class StringDuplicationFiltering
{
    /// <summary>Removes duplicate characters while preserving order.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Deduplicated string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicatesLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return new string(input.Distinct().ToArray());
    }

    /// <summary>Removes duplicate special characters; letters and digits stay untouched.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateSpecialCharsLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var seen = new HashSet<char>();
        return new string(input.Where(c => char.IsLetterOrDigit(c) || seen.Add(c)).ToArray());
    }

    /// <summary>Removes duplicate digits; other characters stay untouched.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateNumbersLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var seen = new HashSet<char>();
        return new string(input.Where(c => !char.IsDigit(c) || seen.Add(c)).ToArray());
    }

    /// <summary>Removes duplicate lowercase letters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateLowerCharsLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var seen = new HashSet<char>();
        return new string(input.Where(c => !char.IsLower(c) || seen.Add(c)).ToArray());
    }

    /// <summary>Removes duplicate uppercase letters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateUpperCharsLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var seen = new HashSet<char>();
        return new string(input.Where(c => !char.IsUpper(c) || seen.Add(c)).ToArray());
    }

    /// <summary>Removes all special characters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveSpecialCharsLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return new string(input.Where(char.IsLetterOrDigit).ToArray());
    }

    /// <summary>Removes all digits.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveNumbersLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return new string(input.Where(c => !char.IsDigit(c)).ToArray());
    }

    /// <summary>Removes all lowercase letters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveLowerCharsLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return new string(input.Where(c => !char.IsLower(c)).ToArray());
    }

    /// <summary>Removes all uppercase letters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveUpperCharsLinq(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        return new string(input.Where(c => !char.IsUpper(c)).ToArray());
    }
}
