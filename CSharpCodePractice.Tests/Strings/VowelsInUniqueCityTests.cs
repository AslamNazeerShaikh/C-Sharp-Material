using ClassCodeLibrary.Strings.VowelsInUniqueCity;

namespace CSharpCodePractice.Tests.Strings;

public sealed class VowelsInUniqueCityTests
{
    [Fact]
    public void RemoveDuplicates_RemovesDuplicatesPreservingOrder()
    {
        string[] input = ["Pune", "Mumbai", "Kolkata", "Munbai", "Kolkata", "Pune"];
        Assert.Equal(
            ["Pune", "Mumbai", "Kolkata", "Munbai"],
            VowelsInUniqueCity.RemoveDuplicates(input)
        );
    }

    [Fact]
    public void FindVowels_ReturnsUniqueLowercaseVowels()
    {
        Assert.Equal(['u', 'e'], VowelsInUniqueCity.FindVowels("Pune"));
        Assert.Equal(['o', 'a'], VowelsInUniqueCity.FindVowels("Kolkata"));
    }

    [Fact]
    public void FindVowels_NoVowels_ReturnsEmpty()
    {
        Assert.Empty(VowelsInUniqueCity.FindVowels("Rhythm"));
    }

    [Fact]
    public void Linq_MatchesManual()
    {
        string[] cities = ["Pune", "Mumbai", "Kolkata", "Munbai", "Kolkata", "Pune"];
        Assert.Equal(
            VowelsInUniqueCity.RemoveDuplicates(cities),
            VowelsInUniqueCity.RemoveDuplicatesLinq(cities)
        );
        Assert.Equal(
            VowelsInUniqueCity.FindVowels("Mumbai"),
            VowelsInUniqueCity.FindVowelsLinq("Mumbai")
        );
    }

    [Fact]
    public void Methods_ThrowWhenNull()
    {
        Assert.Throws<ArgumentNullException>(() => VowelsInUniqueCity.RemoveDuplicates(null!));
        Assert.Throws<ArgumentNullException>(() => VowelsInUniqueCity.FindVowels(null!));
    }
}
