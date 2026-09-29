namespace ClassCodeLibrary.Arrays.SecondLargestNumber;

/// <summary>
/// Finds the second largest distinct number in an integer array.
/// </summary>
public static class SecondLargestNumber
{
    /// <summary>
    /// Finds the second largest distinct value with a single manual pass (no sorting).
    /// </summary>
    /// <param name="nums">The array to search.</param>
    /// <returns>The second largest distinct value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="nums"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the array has fewer than two elements.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no distinct second value exists.</exception>
    public static int FindSecondLargestNumber(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);

        if (nums.Length < 2)
        {
            throw new ArgumentException("Array must contain at least two elements.", nameof(nums));
        }

        int largest = nums[0];
        int? secondLargest = null;

        for (int i = 1; i < nums.Length; i++)
        {
            int current = nums[i];
            if (current > largest)
            {
                secondLargest = largest;
                largest = current;
            }
            else if (current < largest && (secondLargest is null || current > secondLargest))
            {
                secondLargest = current;
            }
        }

        if (secondLargest is null)
        {
            throw new InvalidOperationException("Array does not contain enough distinct elements.");
        }

        return secondLargest.Value;
    }

    /// <summary>
    /// Finds the second largest distinct value using LINQ.
    /// </summary>
    /// <param name="nums">The array to search.</param>
    /// <returns>The second largest distinct value.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="nums"/> is null.</exception>
    /// <exception cref="ArgumentException">Thrown when the array has fewer than two elements.</exception>
    /// <exception cref="InvalidOperationException">Thrown when no distinct second value exists.</exception>
    public static int FindSecondLargestNumberLinq(int[] nums)
    {
        ArgumentNullException.ThrowIfNull(nums);

        if (nums.Length < 2)
        {
            throw new ArgumentException("Array must contain at least two elements.", nameof(nums));
        }

        return nums.Distinct().OrderByDescending(n => n).Skip(1).First();
    }
}
