---
name: format
description: Format CSharpCodePractice code (CSharpier for C#)
category: quality
command: dotnet csharpier
args:
  - name: check
    description: Only check formatting, don't modify
    type: boolean
    default: false
examples:
  - dotnet tool restore
  - dotnet csharpier format .
  - dotnet csharpier check .
