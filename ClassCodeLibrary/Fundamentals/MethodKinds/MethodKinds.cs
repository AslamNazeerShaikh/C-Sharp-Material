namespace ClassCodeLibrary.Fundamentals.MethodKinds;

/// <summary>
/// Stateless arithmetic helpers. Static because <c>Add(a, b)</c> needs no object state:
/// same inputs always give the same output.
/// </summary>
public static class Calculator
{
    /// <summary>Adds two integers. Pure function, thread-safe.</summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>The sum <c>a + b</c>.</returns>
    public static int Add(int a, int b) => a + b;

    /// <summary>
    /// Async variant. <c>async</c>/<c>await</c> works on static methods;
    /// use it for I/O-bound work, not for plain CPU arithmetic like this.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <param name="cancellationToken">Cancellation token.</param>
    /// <returns>The sum <c>a + b</c>.</returns>
    public static async Task<int> AddAsync(
        int a,
        int b,
        CancellationToken cancellationToken = default
    )
    {
        await Task.Delay(1, cancellationToken).ConfigureAwait(false);
        return a + b;
    }

    /// <summary>
    /// <c>ref</c>/<c>out</c>/<c>in</c> parameter modes work on static methods too;
    /// they are orthogonal to static vs instance.
    /// </summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <param name="result">Receives the sum.</param>
    public static void AddIntoRef(int a, int b, ref int result) => result = a + b;
}

/// <summary>
/// Stateful accumulator. Instance because each object carries its own <see cref="Total"/>.
/// </summary>
public sealed class Accumulator
{
    /// <summary>Gets the running total.</summary>
    public int Total { get; private set; }

    /// <summary>Adds a value to this instance's total and returns the new total.</summary>
    /// <param name="value">Value to accumulate.</param>
    /// <returns>The updated total.</returns>
    public int Add(int value)
    {
        Total += value;
        return Total;
    }

    /// <summary>Resets this instance's total to zero.</summary>
    public void Reset() => Total = 0;
}

/// <summary>
/// Abstraction for addition. An interface can only be implemented by instance
/// members, which is why DI, mocking, and polymorphism require instance methods.
/// </summary>
public interface IAdder
{
    /// <summary>Adds two integers.</summary>
    /// <param name="a">First operand.</param>
    /// <param name="b">Second operand.</param>
    /// <returns>The sum <c>a + b</c>.</returns>
    int Add(int a, int b);
}

/// <summary>Default <see cref="IAdder"/> implementation.</summary>
public sealed class Adder : IAdder
{
    /// <inheritdoc />
    public int Add(int a, int b) => a + b;
}

/// <summary>
/// Extension methods: static methods that read like instance calls on types you
/// do not own. Resolved at compile time; no virtual dispatch.
/// </summary>
public static class IntExtensions
{
    /// <summary>Checks whether a value is even.</summary>
    /// <param name="value">The value to test.</param>
    /// <returns>True when even.</returns>
    public static bool IsEven(this int value) => value % 2 == 0;

    /// <summary>Adds another value, callable as <c>2.AddTo(3)</c>.</summary>
    /// <param name="value">The receiver.</param>
    /// <param name="other">The value to add.</param>
    /// <returns>The sum.</returns>
    public static int AddTo(this int value, int other) => value + other;
}
