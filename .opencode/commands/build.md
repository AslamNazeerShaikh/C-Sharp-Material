---
name: build
description: Build CSharpCodePractice.slnx (net10.0)
category: build
command: dotnet build
args:
  - name: solution
    description: Solution to build
    type: string
    default: CSharpCodePractice.slnx
    choices: [CSharpCodePractice.slnx]
  - name: configuration
    description: Build configuration
    type: string
    default: Debug
    choices: [Debug, Release]
examples:
  - dotnet build CSharpCodePractice.slnx
  - dotnet build CSharpCodePractice.slnx -c Release
  - dotnet build MainConsoleApp/MainConsoleApp.csproj --no-restore
