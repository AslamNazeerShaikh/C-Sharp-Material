---
name: dotnet-test
description: Run xunit tests for CSharpCodePractice.slnx (net10.0)
category: test
command: dotnet test
args:
  - name: solution
    description: Solution to test
    type: string
    default: CSharpCodePractice.slnx
    choices: [CSharpCodePractice.slnx]
  - name: configuration
    description: Build configuration
    type: string
    default: Debug
    choices: [Debug, Release]
  - name: filter
    description: Test filter expression
    type: string
    default: ""
  - name: collect-coverage
    description: Collect code coverage
    type: boolean
    default: false
  - name: verbosity
    description: Verbosity level
    type: string
    default: normal
    choices: [quiet, minimal, normal, detailed, diagnostic]
examples:
  - dotnet test CSharpCodePractice.slnx
  - dotnet test CSharpCodePractice.slnx -c Release
  - dotnet test CSharpCodePractice.slnx --filter "FullyQualifiedName~SecondLargestNumber"
  - dotnet test CSharpCodePractice.slnx --collect:"XPlat Code Coverage"
  - dotnet test CSharpCodePractice.slnx --logger "console;verbosity=detailed"
