---
name: default
description: LSP configuration for CSharpCodePractice (.NET 10 console + class library)
version: 1.0.0
enabled: true
servers:
  # C# Language Server (csharp-ls - modern, fast)
  - name: csharp-ls
    command: csharp-ls
    args: []
    filetypes:
      - csharp
    rootPatterns:
      - "*.slnx"
      - "*.sln"
      - "*.csproj"
      - "global.json"
      - "Directory.Build.props"
      - "Directory.Build.targets"

  # JSON Language Server (opencode.json, appsettings)
  - name: json-language-server
    command: vscode-json-language-server
    args:
      - --stdio
    filetypes:
      - json
    rootPatterns:
      - package.json

settings:
  # General settings
  completion:
    triggerCharacters: [".", ":", "<", "@", "#"]
    resolveTimeout: 5000

  diagnostics:
    enable: true
    debounce: 300

  # C# specific settings
  csharp:
    formatting:
      enable: true
      indentSize: 4
      tabSize: 4
      useTabs: false
      newLine: "\n"
    completion:
      triggerCharacters: [".", "(", "<", "@", "#", "?"]
      provideRegexCompletion: true
    diagnostics:
      enable: true
      enableSuppress: true
    semanticTokens:
      enable: true
    inlayHints:
      enable: true
      parameterNames: true
      typeAnnotations: true
    navigation:
      enable: true
