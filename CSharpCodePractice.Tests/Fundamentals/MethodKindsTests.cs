using ClassCodeLibrary.Fundamentals.MethodKinds;

namespace CSharpCodePractice.Tests.Fundamentals;

public sealed class MethodKindsTests
{
    [Fact]
    public void Calculator_Add_ReturnsSum()
    {
        Assert.Equal(5, Calculator.Add(2, 3));
    }

    [Fact]
    public async Task Calculator_AddAsync_ReturnsSum()
    {
        Assert.Equal(5, await Calculator.AddAsync(2, 3));
    }

    [Fact]
    public void Calculator_AddIntoRef_WritesResult_ProvingRefWorksOnStatic()
    {
        int result = 0;
        Calculator.AddIntoRef(2, 3, ref result);
        Assert.Equal(5, result);
    }

    [Fact]
    public void Accumulator_InstancesKeepIndependentState()
    {
        var first = new Accumulator();
        var second = new Accumulator();

        Assert.Equal(2, first.Add(2));
        Assert.Equal(10, second.Add(10));

        first.Add(3);
        Assert.Equal(5, first.Total);
        Assert.Equal(10, second.Total);

        first.Reset();
        Assert.Equal(0, first.Total);
        Assert.Equal(10, second.Total);
    }

    [Fact]
    public void Adder_ImplementsIAdder_UsableViaInterface()
    {
        IAdder adder = new Adder();
        Assert.Equal(5, adder.Add(2, 3));
    }

    [Fact]
    public void IntExtensions_WorkAsInstanceStyleCalls()
    {
        Assert.True(4.IsEven());
        Assert.False(3.IsEven());
        Assert.Equal(5, 2.AddTo(3));
    }
}
