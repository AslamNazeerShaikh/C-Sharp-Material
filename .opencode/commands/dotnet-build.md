---
name: dotnet-build
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
  - name: no-restore
    description: Skip implicit restore
    type: boolean
    default: false
  - name: verbosity
    description: Verbosity level
    type: string
    default: minimal
    choices: [quiet, minimal, normal, detailed, diagnostic]
examples:
  - dotnet build CSharpCodePractice.slnx
  - dotnet build CSharpCodePractice.slnx -c Release
  - dotnet build CSharpCodePractice.slnx --no-restore -v normal
