using ClassCodeLibrary.Common;

namespace ClassCodeLibrary.Arrays.CustomArraySorter;

/// <summary>
/// Generic array sorting: built-in vs. manual bubble sort. Both return a new sorted copy.
/// </summary>
public static class CustomArraySorter
{
    /// <summary>
    /// Sorts a copy of the array using built-in <see cref="Array.Sort{T}(T[])"/>.
    /// </summary>
    /// <typeparam name="T">Element type, must be comparable.</typeparam>
    /// <param name="inputArray">The array to sort.</param>
    /// <param name="direction">Ascending or descending.</param>
    /// <returns>A new sorted array; the input is not modified.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputArray"/> is null.</exception>
    public static T[] SortWithBuiltIn<T>(T[] inputArray, SortDirection direction)
        where T : IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(inputArray);

        T[] copy = (T[])inputArray.Clone();
        if (copy.Length == 0)
        {
            return copy;
        }

        if (direction == SortDirection.Ascending)
        {
            Array.Sort(copy);
        }
        else
        {
            Array.Sort(copy, (x, y) => y!.CompareTo(x!));
        }

        return copy;
    }

    /// <summary>
    /// Sorts a copy of the array using manual bubble sort (no built-in sort calls).
    /// </summary>
    /// <typeparam name="T">Element type, must be comparable.</typeparam>
    /// <param name="inputArray">The array to sort.</param>
    /// <param name="direction">Ascending or descending.</param>
    /// <returns>A new sorted array; the input is not modified.</returns>
    /// <exception cref="ArgumentNullException">Thrown when <paramref name="inputArray"/> is null.</exception>
    public static T[] SortWithBubbleSort<T>(T[] inputArray, SortDirection direction)
        where T : IComparable<T>
    {
        ArgumentNullException.ThrowIfNull(inputArray);

        T[] copy = (T[])inputArray.Clone();

        for (int i = 0; i < copy.Length - 1; i++)
        {
            bool swapped = false;
            for (int j = 0; j < copy.Length - i - 1; j++)
            {
                int comparison = copy[j].CompareTo(copy[j + 1]);
                bool outOfOrder =
                    direction == SortDirection.Ascending ? comparison > 0 : comparison < 0;
                if (outOfOrder)
                {
                    (copy[j], copy[j + 1]) = (copy[j + 1], copy[j]);
                    swapped = true;
                }
            }

            if (!swapped)
            {
                break;
            }
        }

        return copy;
    }
}
