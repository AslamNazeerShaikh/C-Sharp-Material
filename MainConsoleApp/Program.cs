using ClassCodeLibrary.Arrays.CustomArraySorter;
using ClassCodeLibrary.Arrays.SecondLargestNumber;
using ClassCodeLibrary.Common;
using ClassCodeLibrary.Strings.StringDuplicationFiltering;
using ClassCodeLibrary.Strings.UniqueCharacterCounter;
using ClassCodeLibrary.Strings.VowelsInUniqueCity;

namespace MainConsoleApp;

/// <summary>
/// Menu runner for interview demos. Library stays pure; all console output lives here.
/// </summary>
public static class Program
{
    private static readonly Dictionary<string, (string Name, Action Demo)> Demos = new()
    {
        ["1"] = ("Vowels in unique city", DemoVowelsInUniqueCity),
        ["2"] = ("Unique character counter", DemoUniqueCharacterCounter),
        ["3"] = ("Custom array sorter", DemoCustomArraySorter),
        ["4"] = ("Second largest number", DemoSecondLargestNumber),
        ["5"] = ("String duplication filtering", DemoStringDuplicationFiltering),
    };

    /// <summary>
    /// Program entry point: shows a menu and runs the chosen demo.
    /// </summary>
    /// <param name="args">Unused.</param>
    public static void Main(string[] args)
    {
        while (true)
        {
            Console.WriteLine("C# interview practice - pick a demo:");
            foreach (var entry in Demos)
            {
                Console.WriteLine($"  {entry.Key}. {entry.Value.Name}");
            }

            Console.WriteLine("  q. Quit");
            Console.Write("Choice: ");
            string? choice = Console.ReadLine()?.Trim().ToLowerInvariant();

            if (choice == "q" || choice == "quit" || choice == "exit")
            {
                return;
            }

            if (choice is not null && Demos.TryGetValue(choice, out var selected))
            {
                Console.WriteLine($"--- {selected.Name} ---");
                selected.Demo();
            }
            else
            {
                Console.WriteLine("Unknown choice. Try 1-5 or q.");
            }

            Console.WriteLine();
        }
    }

    private static void DemoVowelsInUniqueCity()
    {
        string[] cities = ["Pune", "Mumbai", "Kolkata", "Munbai", "Kolkata", "Pune"];
        string[] uniqueCities = VowelsInUniqueCity.RemoveDuplicates(cities);
        foreach (string city in uniqueCities)
        {
            char[] vowels = VowelsInUniqueCity.FindVowels(city);
            Console.WriteLine($"City: {city}, Vowels: {new string(vowels)}");
        }
    }

    private static void DemoUniqueCharacterCounter()
    {
        string example = "AaaakkasklkdddekeooPOxOKMNNHHHDOBBBbbzhhsh";
        foreach ((char c, int count) in UniqueCharacterCounter.CountUniqueCharacters(example))
        {
            Console.WriteLine($"Character '{c}': {count} times");
        }
    }

    private static void DemoCustomArraySorter()
    {
        int[] input = [24, 58, 99, 67, 75, 44, 73, 41, 74, 87];
        Console.WriteLine(
            "Built-in ascending: "
                + string.Join(
                    " ",
                    CustomArraySorter.SortWithBuiltIn(input, SortDirection.Ascending)
                )
        );
        Console.WriteLine(
            "Bubble ascending:   "
                + string.Join(
                    " ",
                    CustomArraySorter.SortWithBubbleSort(input, SortDirection.Ascending)
                )
        );
        Console.WriteLine(
            "Built-in descending: "
                + string.Join(
                    " ",
                    CustomArraySorter.SortWithBuiltIn(input, SortDirection.Descending)
                )
        );
        Console.WriteLine(
            "Bubble descending:   "
                + string.Join(
                    " ",
                    CustomArraySorter.SortWithBubbleSort(input, SortDirection.Descending)
                )
        );
    }

    private static void DemoSecondLargestNumber()
    {
        int[][] cases =
        [
            [3, 1, 4, 4, 5, 2, 5],
            [1],
            [5, 5, 5],
        ];
        foreach (int[] testCase in cases)
        {
            try
            {
                Console.WriteLine(
                    $"[{string.Join(", ", testCase)}] -> Second largest: {SecondLargestNumber.FindSecondLargestNumber(testCase)}"
                );
            }
            catch (Exception ex)
            {
                Console.WriteLine($"[{string.Join(", ", testCase)}] -> Error: {ex.Message}");
            }
        }
    }

    private static void DemoStringDuplicationFiltering()
    {
        string input =
            "sdfsdfasdgfd%^^%$.....}{}{:\"<><><,.,//.?"
            + "|\\';';/:\":>?>?}||}{}<><><><><>,.,/,/';';\">[]\\"
            + "-=-=%$#@#@^%^*)*(*&*&^&@##!CGDGFDDDAGHGAG65465456314544544";

        Console.WriteLine("Original: " + input);
        Console.WriteLine("Remove all duplicates: " + input.RemoveDuplicates());
        Console.WriteLine("Remove duplicate special chars: " + input.RemoveDuplicateSpecialChars());
        Console.WriteLine("Remove duplicate numbers: " + input.RemoveDuplicateNumbers());
        Console.WriteLine("Remove duplicate lowercase chars: " + input.RemoveDuplicateLowerChars());
        Console.WriteLine("Remove duplicate uppercase chars: " + input.RemoveDuplicateUpperChars());
        Console.WriteLine("Remove all special chars: " + input.RemoveSpecialChars());
        Console.WriteLine("Remove all numbers: " + input.RemoveNumbers());
        Console.WriteLine("Remove all lowercase chars: " + input.RemoveLowerChars());
        Console.WriteLine("Remove all uppercase chars: " + input.RemoveUpperChars());
    }
}
