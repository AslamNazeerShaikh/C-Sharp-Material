---
name: testing-strategy
description: xunit + Moq + Bogus + FluentAssertions strategy for CSharpCodePractice
version: 1.0.0
author: opencode
tags:
  - testing
  - xunit
  - moq
  - bogus
  - fluentassertions
capabilities:
  - unit-testing
  - test-fixtures
  - coverage-analysis
references:
  - "https://xunit.net/"
  - "https://documentation.help/Moq/"
  - "https://github.com/bchavez/Bogus"
  - "https://fluentassertions.com/"
examples:
  - name: "Test project references (pinned, net10.0)"
    description: "Stack for the future *.Tests project; add it alongside the existing two projects"
    code: |
      <ItemGroup>
        <PackageReference Include="Bogus" Version="35.6.5" />
        <PackageReference Include="coverlet.collector" Version="6.0.4" />
        <PackageReference Include="FluentAssertions" Version="8.11.0" />
        <PackageReference Include="Microsoft.NET.Test.Sdk" Version="17.14.1" />
        <PackageReference Include="Moq" Version="4.20.72" />
        <PackageReference Include="xunit" Version="2.9.3" />
        <PackageReference Include="xunit.runner.visualstudio" Version="3.1.4" />
      </ItemGroup>
  - name: "Exercise test with edge cases"
    description: "One test class per topic; edge cases first, FluentAssertions, should_when naming"
    code: |
      [Theory]
      [InlineData("", 0)]
      [InlineData("a", 1)]
      [InlineData("hello", 2)]
      public void should_count_unique_vowels_when_given_words(string input, int expected)
      {
          VowelCounter.CountUnique(input).Should().Be(expected);
      }
  - name: "Bogus fixtures for generated inputs"
    description: "Randomized strings/arrays for property-style checks"
    code: |
      var faker = new Faker();
      var words = Enumerable.Range(0, 20).Select(_ => faker.Random.String2(1, 12)).ToList();
      words.Should().HaveCount(20);
  - name: "Run + coverage"
    description: "Single solution; coverlet collects without extra config"
    code: |
      dotnet test CSharpCodePractice.slnx
      dotnet test CSharpCodePractice.slnx --collect:"XPlat Code Coverage"
