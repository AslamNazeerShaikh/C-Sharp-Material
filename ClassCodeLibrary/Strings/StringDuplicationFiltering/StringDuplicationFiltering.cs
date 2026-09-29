using System.Text;

namespace ClassCodeLibrary.Strings.StringDuplicationFiltering;

/// <summary>
/// Manual (no LINQ / no collections) string filtering. Pure functions: no console output.
/// </summary>
public static partial class StringDuplicationFiltering
{
    private static bool ContainsChar(StringBuilder sb, char c)
    {
        for (int i = 0; i < sb.Length; i++)
        {
            if (sb[i] == c)
            {
                return true;
            }
        }

        return false;
    }

    private static bool IsLetterOrDigit(char c) =>
        (c >= 'A' && c <= 'Z') || (c >= 'a' && c <= 'z') || (c >= '0' && c <= '9');

    private static bool IsDigit(char c) => c >= '0' && c <= '9';

    private static bool IsLower(char c) => c >= 'a' && c <= 'z';

    private static bool IsUpper(char c) => c >= 'A' && c <= 'Z';

    /// <summary>Removes all duplicate characters, keeping first occurrences.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Deduplicated string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicates(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (!ContainsChar(result, c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes duplicate special characters only; letters and digits stay untouched.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateSpecialChars(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        var seenSpecials = new StringBuilder();
        foreach (char c in input)
        {
            if (!IsLetterOrDigit(c))
            {
                if (!ContainsChar(seenSpecials, c))
                {
                    result.Append(c);
                    seenSpecials.Append(c);
                }
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes duplicate digits only; other characters stay untouched.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateNumbers(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        var seenNumbers = new StringBuilder();
        foreach (char c in input)
        {
            if (IsDigit(c))
            {
                if (!ContainsChar(seenNumbers, c))
                {
                    result.Append(c);
                    seenNumbers.Append(c);
                }
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes duplicate lowercase letters only.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateLowerChars(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        var seenLower = new StringBuilder();
        foreach (char c in input)
        {
            if (IsLower(c))
            {
                if (!ContainsChar(seenLower, c))
                {
                    result.Append(c);
                    seenLower.Append(c);
                }
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes duplicate uppercase letters only.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveDuplicateUpperChars(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        var seenUpper = new StringBuilder();
        foreach (char c in input)
        {
            if (IsUpper(c))
            {
                if (!ContainsChar(seenUpper, c))
                {
                    result.Append(c);
                    seenUpper.Append(c);
                }
            }
            else
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes all special characters, keeping letters and digits.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveSpecialChars(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (IsLetterOrDigit(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes all digits.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveNumbers(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (!IsDigit(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes all lowercase letters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveLowerChars(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (!IsLower(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }

    /// <summary>Removes all uppercase letters.</summary>
    /// <param name="input">The input string.</param>
    /// <returns>Filtered string.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="input"/> is null.</exception>
    public static string RemoveUpperChars(this string input)
    {
        ArgumentNullException.ThrowIfNull(input);

        var result = new StringBuilder(input.Length);
        foreach (char c in input)
        {
            if (!IsUpper(c))
            {
                result.Append(c);
            }
        }

        return result.ToString();
    }
}
