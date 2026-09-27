---
name: csharp-development
description: Modern C# .NET development practices for console + class-library exercises (manual-first, LINQ comparisons)
version: 1.0.0
author: opencode
tags:
  - csharp
  - dotnet
  - console
  - linq
  - algorithms
capabilities:
  - idiomatic-csharp
  - manual-before-linq
  - dependency-injection
  - async-patterns
  - records-pattern-matching
  - nullable-reference-types
references:
  - "https://learn.microsoft.com/dotnet/csharp/"
  - "https://learn.microsoft.com/dotnet/csharp/fundamentals/nullable-reference-types"
  - "https://learn.microsoft.com/dotnet/csharp/linq/"
examples:
  - name: "Manual string reverse (no built-ins)"
    description: "Practice-first implementation using char array swaps, as in StringDuplicationFiltering"
    code: |
      /// <summary>Reverses a string without built-in reverse helpers.</summary>
      public static string Reverse(string input)
      {
          ArgumentNullException.ThrowIfNull(input);
          var chars = input.ToCharArray();
          for (int left = 0, right = chars.Length - 1; left < right; left++, right--)
          {
              (chars[left], chars[right]) = (chars[right], chars[left]);
          }
          return new string(chars);
      }

  - name: "LINQ comparison next to the manual version"
    description: "Keep both files where instructive, mirroring StringDuplicationFiltering.cs + StringDuplicationFilteringLinq.cs"
    code: |
      /// <summary>LINQ equivalent kept beside the manual implementation for comparison.</summary>
      public static string ReverseLinq(string input)
      {
          ArgumentNullException.ThrowIfNull(input);
          return new string(input.Reverse().ToArray());
      }

  - name: "Second largest in one pass"
    description: "O(n) single scan tracking largest and second largest; handles duplicates"
    code: |
      /// <summary>Finds the second largest distinct value in one pass.</summary>
      /// <exception cref="ArgumentException">Thrown when fewer than two distinct values exist.</exception>
      public static int Find(int[] numbers)
      {
          ArgumentNullException.ThrowIfNull(numbers);
          int? largest = null, second = null;
          foreach (var n in numbers)
          {
              if (n == largest) continue;
              if (largest is null || n > largest) { second = largest; largest = n; }
              else if (second is null || n > second) { second = n; }
          }
          return second ?? throw new ArgumentException("Need at least two distinct values.", nameof(numbers));
      }

  - name: "Records with pattern matching"
    description: "Immutable models plus switch expressions for classification exercises"
    code: |
      /// <summary>Exercise result carrying the topic name and complexity.</summary>
      public record ExerciseResult(string Topic, string Complexity, bool Passed);

      public static string Grade(ExerciseResult result) => result switch
      {
          { Passed: false } => $"Retry: {result.Topic}",
          { Complexity: "O(1)" } => $"Optimal: {result.Topic}",
          _ => $"Done: {result.Topic} ({result.Complexity})"
      };

  - name: "Async console entry point"
    description: "Async Main with cancellation for I/O-bound demos in MainConsoleApp"
    code: |
      using ClassCodeLibrary.VowelsInUniqueCity;

      using var cts = new CancellationTokenSource(TimeSpan.FromSeconds(30));
      var count = await VowelCounter.CountAsync("Minneapolis", cts.Token);
      Console.WriteLine($"Unique vowels: {count}");
