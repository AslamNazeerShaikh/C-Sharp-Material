---
name: lint
description: Static analysis for CSharpCodePractice (Roslyn analyzers via build)
category: quality
command: dotnet build
args:
  - name: solution
    description: Solution to analyze
    type: string
    default: CSharpCodePractice.slnx
    choices: [CSharpCodePractice.slnx]
  - name: warnings-as-errors
    description: Treat warnings as errors
    type: boolean
    default: true
examples:
  - dotnet build CSharpCodePractice.slnx -c Release /p:TreatWarningsAsErrors=true
