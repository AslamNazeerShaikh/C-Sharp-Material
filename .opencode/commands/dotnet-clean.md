---
name: dotnet-clean
description: Clean CSharpCodePractice.slnx
category: build
command: dotnet clean
args:
  - name: solution
    description: Solution to clean
    type: string
    default: CSharpCodePractice.slnx
    choices: [CSharpCodePractice.slnx]
  - name: configuration
    description: Build configuration
    type: string
    default: Debug
    choices: [Debug, Release]
examples:
  - dotnet clean CSharpCodePractice.slnx
  - dotnet clean CSharpCodePractice.slnx -c Release
