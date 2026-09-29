using ClassCodeLibrary.Arrays.SecondLargestNumber;

namespace CSharpCodePractice.Tests.Arrays;

public sealed class SecondLargestNumberTests
{
    [Fact]
    public void FindSecondLargestNumber_ReturnsExpectedValue()
    {
        Assert.Equal(4, SecondLargestNumber.FindSecondLargestNumber([3, 1, 4, 4, 5, 2, 5]));
    }

    [Fact]
    public void FindSecondLargestNumber_HandlesIntMinValueSentinel()
    {
        Assert.Equal(int.MinValue, SecondLargestNumber.FindSecondLargestNumber([0, int.MinValue]));
    }

    [Fact]
    public void FindSecondLargestNumber_HandlesNegatives()
    {
        Assert.Equal(-5, SecondLargestNumber.FindSecondLargestNumber([-5, -2, -9, -2]));
    }

    [Fact]
    public void FindSecondLargestNumber_ThrowsWhenTooShort()
    {
        Assert.Throws<ArgumentException>(() => SecondLargestNumber.FindSecondLargestNumber([1]));
    }

    [Fact]
    public void FindSecondLargestNumber_ThrowsWhenAllIdentical()
    {
        Assert.Throws<InvalidOperationException>(() =>
            SecondLargestNumber.FindSecondLargestNumber([5, 5, 5])
        );
    }

    [Fact]
    public void FindSecondLargestNumber_ThrowsWhenNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            SecondLargestNumber.FindSecondLargestNumber(null!)
        );
    }

    [Theory]
    [InlineData(new[] { 3, 1, 4, 4, 5, 2, 5 }, 4)]
    [InlineData(new[] { 10, 10, 9 }, 9)]
    [InlineData(new[] { 1, 2 }, 1)]
    public void Linq_MatchesManual(int[] input, int expected)
    {
        Assert.Equal(expected, SecondLargestNumber.FindSecondLargestNumberLinq(input));
        Assert.Equal(expected, SecondLargestNumber.FindSecondLargestNumber(input));
    }
}
