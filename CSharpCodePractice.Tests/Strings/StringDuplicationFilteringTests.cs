using ClassCodeLibrary.Strings.StringDuplicationFiltering;

namespace CSharpCodePractice.Tests.Strings;

public sealed class StringDuplicationFilteringTests
{
    [Fact]
    public void RemoveDuplicates_KeepsFirstOccurrence()
    {
        Assert.Equal("abc", "aabbcc".RemoveDuplicates());
    }

    [Fact]
    public void RemoveDuplicateSpecialChars_KeepsLetterDuplicates()
    {
        Assert.Equal("aabb!", "aabb!!!!".RemoveDuplicateSpecialChars());
    }

    [Fact]
    public void RemoveDuplicateNumbers_KeepsOtherDuplicates()
    {
        Assert.Equal("aabb12", "aabb1122".RemoveDuplicateNumbers());
    }

    [Fact]
    public void RemoveSpecialChars_RemovesAllSpecials()
    {
        Assert.Equal("abc123", "a!b@c#123".RemoveSpecialChars());
    }

    [Fact]
    public void RemoveNumbers_RemovesAllDigits()
    {
        Assert.Equal("abc", "a1b2c3".RemoveNumbers());
    }

    [Fact]
    public void RemoveLowerChars_RemovesLowercase()
    {
        Assert.Equal("ABC123", "aAbBcC123".RemoveLowerChars());
    }

    [Fact]
    public void RemoveUpperChars_RemovesUppercase()
    {
        Assert.Equal("abc123", "aAbBcC123".RemoveUpperChars());
    }

    [Theory]
    [InlineData("aabb!!@@11AAaa")]
    [InlineData("sdf%^^%$..}{}{")]
    public void Linq_MatchesManual(string input)
    {
        Assert.Equal(input.RemoveDuplicates(), input.RemoveDuplicatesLinq());
        Assert.Equal(input.RemoveDuplicateSpecialChars(), input.RemoveDuplicateSpecialCharsLinq());
        Assert.Equal(input.RemoveDuplicateNumbers(), input.RemoveDuplicateNumbersLinq());
        Assert.Equal(input.RemoveDuplicateLowerChars(), input.RemoveDuplicateLowerCharsLinq());
        Assert.Equal(input.RemoveDuplicateUpperChars(), input.RemoveDuplicateUpperCharsLinq());
        Assert.Equal(input.RemoveSpecialChars(), input.RemoveSpecialCharsLinq());
        Assert.Equal(input.RemoveNumbers(), input.RemoveNumbersLinq());
        Assert.Equal(input.RemoveLowerChars(), input.RemoveLowerCharsLinq());
        Assert.Equal(input.RemoveUpperChars(), input.RemoveUpperCharsLinq());
    }

    [Fact]
    public void Methods_ThrowWhenNull()
    {
        string? nullString = null;
        Assert.Throws<ArgumentNullException>(() => nullString!.RemoveDuplicates());
        Assert.Throws<ArgumentNullException>(() => nullString!.RemoveDuplicatesLinq());
    }
}
