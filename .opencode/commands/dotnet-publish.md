---
name: dotnet-publish
description: Publish MainConsoleApp (Release, net10.0)
category: build
command: dotnet publish
args:
  - name: project
    description: Project to publish
    type: string
    default: MainConsoleApp/MainConsoleApp.csproj
    choices: [MainConsoleApp/MainConsoleApp.csproj, ClassCodeLibrary/ClassCodeLibrary.csproj]
  - name: configuration
    description: Build configuration
    type: string
    default: Release
    choices: [Debug, Release]
  - name: runtime-identifier
    description: Runtime identifier (empty = portable)
    type: string
    default: ""
  - name: output
    description: Output directory
    type: string
    default: ""
examples:
  - dotnet publish MainConsoleApp -c Release
  - dotnet publish MainConsoleApp -c Release -r osx-arm64
