# CSharpCodePractice — agent instructions

C# logic-building practice repo. Single solution `CSharpCodePractice.slnx`: `MainConsoleApp/` (Exe demos) + `ClassCodeLibrary/` (one folder per exercise, `<Topic>.cs` + `<Topic>.md` notes).

## Toolchain

- .NET SDK 10.0.400, `net10.0`, `<Nullable>enable</Nullable>`, `<ImplicitUsings>enable</ImplicitUsings>`.
- Bare `dotnet build` / `dotnet test` auto-discover the single `.slnx`; run demos with `dotnet run --project MainConsoleApp`.
- Formatter: CSharpier 1.3.0 as a local dotnet tool (`.config/dotnet-tools.json`) — `dotnet tool restore`, then `dotnet csharpier format .` / `check .`.
- Full agent/skill/command inventory lives in `.opencode/README.md`; config in `.opencode/opencode.json`.

## Conventions

- New exercise = new folder under `ClassCodeLibrary/` with implementation `.cs` + notes `.md`, mirroring the existing pairs.
- Practice-first: manual implementation before the LINQ/built-in shortcut; keep both where instructive.
- XML doc comments (`///`) on all public types/members; UTC timestamps (`DateTime.UtcNow`, never `DateTime.Now`).
- Never install toolchains, packages, or tools automatically — give copy-pasteable commands instead.

## Guardrails

- Destructive bash is denied (`rm -rf *`, `sudo *`, `chmod 777 *`, force-push, `curl * | bash` — full list in `.opencode/permissions/default.md`).
- Never read or write secrets (`.env*`, `*.key`, `*.pem`, `secrets.*`, `credentials.*`).

## graphify

This project uses the shared graphify skill (`.opencode/skills/graphify/`) and reminder plugin (`.opencode/plugins/graphify.js`).

Rules (apply once `graphify-out/graph.json` exists):

- For codebase questions, first run `graphify query "<question>"`. Use `graphify path "<A>" "<B>"` for relationships and `graphify explain "<concept>"` for focused concepts.
- If `graphify-out/wiki/index.md` exists, use it for broad navigation instead of raw source browsing.
- Read `graphify-out/GRAPH_REPORT.md` only for broad architecture review or when query/path/explain do not surface enough context.
- After modifying code, run `graphify update .` to keep the graph current (AST-only, no API cost).
