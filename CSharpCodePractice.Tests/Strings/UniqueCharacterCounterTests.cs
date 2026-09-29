using ClassCodeLibrary.Strings.UniqueCharacterCounter;

namespace CSharpCodePractice.Tests.Strings;

public sealed class UniqueCharacterCounterTests
{
    [Fact]
    public void Count_ReturnsExpectedCounts()
    {
        var result = UniqueCharacterCounter.CountUniqueCharacters("aabbA");
        Assert.Equal(2, result['a']);
        Assert.Equal(2, result['b']);
        Assert.Equal(1, result['A']);
    }

    [Fact]
    public void Count_Empty_ReturnsEmpty()
    {
        Assert.Empty(UniqueCharacterCounter.CountUniqueCharacters(string.Empty));
    }

    [Fact]
    public void Count_ThrowsWhenNull()
    {
        Assert.Throws<ArgumentNullException>(() =>
            UniqueCharacterCounter.CountUniqueCharacters(null!)
        );
    }

    [Fact]
    public void Linq_MatchesManual()
    {
        const string input = "AaaakkasklkdddekeooPOxOKMNNHHHDOBBBbbzhhsh";
        Assert.Equal(
            UniqueCharacterCounter.CountUniqueCharacters(input),
            UniqueCharacterCounter.CountUniqueCharactersLinq(input)
        );
    }
}
