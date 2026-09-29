using ClassCodeLibrary.Arrays.CustomArraySorter;
using ClassCodeLibrary.Common;

namespace CSharpCodePractice.Tests.Arrays;

public sealed class CustomArraySorterTests
{
    [Fact]
    public void BubbleSort_Ascending_MatchesBuiltIn()
    {
        int[] input = [24, 58, 99, 67, 75, 44, 73, 41, 74, 87];
        Assert.Equal(
            CustomArraySorter.SortWithBuiltIn(input, SortDirection.Ascending),
            CustomArraySorter.SortWithBubbleSort(input, SortDirection.Ascending)
        );
    }

    [Fact]
    public void BubbleSort_Descending_MatchesBuiltIn()
    {
        int[] input = [24, 58, 99, 67, 75, 44, 73, 41, 74, 87];
        Assert.Equal(
            CustomArraySorter.SortWithBuiltIn(input, SortDirection.Descending),
            CustomArraySorter.SortWithBubbleSort(input, SortDirection.Descending)
        );
    }

    [Fact]
    public void Sort_DoesNotMutateInput()
    {
        int[] input = [3, 1, 2];
        CustomArraySorter.SortWithBubbleSort(input, SortDirection.Ascending);
        Assert.Equal([3, 1, 2], input);
    }

    [Fact]
    public void Sort_Empty_ReturnsEmpty()
    {
        Assert.Empty(CustomArraySorter.SortWithBubbleSort<int>([], SortDirection.Ascending));
    }

    [Fact]
    public void Sort_WorksForStrings()
    {
        string[] input = ["pear", "apple", "fig"];
        Assert.Equal(
            ["apple", "fig", "pear"],
            CustomArraySorter.SortWithBubbleSort(input, SortDirection.Ascending)
        );
    }

    [Fact]
    public void Sort_ThrowsWhenNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            CustomArraySorter.SortWithBubbleSort<int>(null!, SortDirection.Ascending)
        );
    }
}
