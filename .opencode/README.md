# Opencode Configuration for CSharpCodePractice

C# logic-building practice repo: console demos plus one-folder-per-topic algorithm/string/array exercises with notes.
Model: `opencode/muse-spark-1.3-contributor-free` via OpenCode Zen (reasoning effort high).

## Structure

```
.opencode/
├── opencode.json              # Main configuration (model, agents, skills, commands, MCP)
├── agents/                    # Agent definitions
│   ├── csharp-practice-assistant.md  # Main C# coach (default)
│   ├── code-reviewer.md       # C# review checklist for exercises
│   ├── test-writer.md         # xunit + FluentAssertions specialist
│   └── documentation-writer.md# Keeps README + per-topic notes in sync
├── skills/                    # Skill definitions
│   ├── csharp-development.md  # Console + class-library C# patterns
│   ├── testing-strategy.md    # .NET test stack (pinned versions)
│   └── graphify/              # Knowledge-graph skill (untouched, shared)
├── commands/                  # Custom commands
│   ├── build.md test.md run.md clean.md lint.md format.md   # Shortcuts (single .slnx)
│   └── dotnet-build.md dotnet-test.md dotnet-run.md dotnet-clean.md dotnet-publish.md dotnet-lint.md
├── permissions/               # Permission rules (dotnet + graphify bash allows, destructive denies)
│   └── default.md
├── lsp/                       # csharp-ls + JSON
│   └── default.md
└── plugins/
    └── graphify.js            # Knowledge-graph reminder hook (untouched, shared)
```

## Repo layout (target project)

| Path | Purpose |
|---|---|
| `CSharpCodePractice.slnx` | The only solution (auto-discovered by bare `dotnet` commands) |
| `MainConsoleApp/` | Exe demos, `net10.0` |
| `ClassCodeLibrary/<Topic>/` | One exercise per folder: `<Topic>.cs` + `<Topic>.md` notes |
| `.config/dotnet-tools.json` | Pinned local tools (CSharpier) |

## Agents

| Agent | Purpose |
|-------|---------|
| `csharp-practice-assistant` | Main C# coach (default): new exercises, explanations, manual-before-LINQ |
| `code-reviewer` | Reviews exercises against the checklist |
| `test-writer` | Adds xunit tests when a Tests project exists |
| `documentation-writer` | Keeps root `README.md` + per-topic `.md` notes in sync |

## Skills

| Skill | Description |
|-------|-------------|
| `csharp-development` | Manual implementations, LINQ comparisons, records, nullable, async |
| `testing-strategy` | Pinned xunit/Moq/Bogus/FluentAssertions packages, `dotnet test` runs |

## Commands

| Command | Description |
|---------|-------------|
| `build` / `dotnet-build` | `dotnet build CSharpCodePractice.slnx` |
| `test` / `dotnet-test` | `dotnet test CSharpCodePractice.slnx` (+ `--filter`, coverlet) |
| `run` / `dotnet-run` | `dotnet run --project MainConsoleApp` |
| `clean` / `dotnet-clean` | `dotnet clean CSharpCodePractice.slnx` |
| `lint` / `dotnet-lint` | Roslyn analysis (`TreatWarningsAsErrors`) |
| `format` | CSharpier (`dotnet csharpier format .`; restore tools first) |
| `dotnet-publish` | `dotnet publish MainConsoleApp` (Release, net10.0) |

## Guardrails

- Bash `*` allowed, except destructive commands are denied: `rm -rf *`, `sudo *`, `chmod 777 *` (full deny list in `permissions/default.md`).
- Sensitive files (`.env*`, `*.key`, `*.pem`, `secrets.*`, `credentials.*`) are neither written nor read.
- Never install toolchains/packages on your own — give copy-pasteable commands instead.

## Usage

### Switch Agent
```
> agent code-reviewer
```

### Run Command
```
> build
> test --coverage
```

### Knowledge graph
```
> /graphify
```
(`graphify update .` after code changes once `graphify-out/` exists; see `AGENTS.md`)

## Documentation

- [Opencode Config](https://opencode.ai/docs/config/)
- [Opencode Agents](https://opencode.ai/docs/agents/)
- [Opencode Models](https://opencode.ai/docs/models/) (Zen model IDs use `opencode/<model-id>`)
- [Opencode Commands](https://opencode.ai/docs/commands/)
- [Opencode Permissions](https://opencode.ai/docs/permissions/)
- [Opencode LSP](https://opencode.ai/docs/lsp/)
