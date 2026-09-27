---
name: run
description: Run the MainConsoleApp demo project
category: run
command: dotnet run
args:
  - name: project
    description: Project to run
    type: string
    default: MainConsoleApp/MainConsoleApp.csproj
    choices: [MainConsoleApp/MainConsoleApp.csproj]
  - name: configuration
    description: Build configuration
    type: string
    default: Debug
    choices: [Debug, Release]
examples:
  - dotnet run --project MainConsoleApp
  - dotnet run --project MainConsoleApp -c Release
