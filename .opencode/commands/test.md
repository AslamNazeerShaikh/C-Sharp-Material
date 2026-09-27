---
name: test
description: Run xunit tests for CSharpCodePractice (FluentAssertions + coverlet)
category: test
command: dotnet test
args:
  - name: solution
    description: Solution to test
    type: string
    default: CSharpCodePractice.slnx
    choices: [CSharpCodePractice.slnx]
  - name: filter
    description: Test filter expression
    type: string
    default: ""
  - name: coverage
    description: Collect code coverage (coverlet)
    type: boolean
    default: false
examples:
  - dotnet test CSharpCodePractice.slnx
  - dotnet test CSharpCodePractice.slnx --filter "FullyQualifiedName~SecondLargestNumber"
  - dotnet test CSharpCodePractice.slnx --collect:"XPlat Code Coverage"
