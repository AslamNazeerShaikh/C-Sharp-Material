---
name: dotnet-lint
description: Run Roslyn static analysis on CSharpCodePractice.slnx via build
category: lint
command: dotnet build
args:
  - name: solution
    description: Solution to analyze
    type: string
    default: CSharpCodePractice.slnx
    choices: [CSharpCodePractice.slnx]
  - name: configuration
    description: Build configuration
    type: string
    default: Release
    choices: [Debug, Release]
  - name: warnings-as-errors
    description: Treat warnings as errors
    type: boolean
    default: true
examples:
  - dotnet build CSharpCodePractice.slnx -c Release /p:TreatWarningsAsErrors=true
