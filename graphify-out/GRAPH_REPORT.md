# Graph Report - C-Sharp-Material  (2026-09-29)

## Corpus Check
- cluster-only mode — file stats not available

## Summary
- 273 nodes · 370 edges · 38 communities (16 shown, 22 thin omitted)
- Extraction: 95% EXTRACTED · 5% INFERRED · 0% AMBIGUOUS · INFERRED: 17 edges (avg confidence: 0.84)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `e8292bce`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- MethodKindsTests
- StringDuplicationFiltering
- Program
- opencode.json
- .FindSecondLargestNumber
- .FindVowels
- .SortWithBubbleSort
- StringDuplicationFilteringTests
- OpenCode Configuration
- github
- Program.cs
- permission
- Graphify full pipeline (detect extract build cluster report)
- CSharpCodePractice.Tests
- VowelsInUniqueCity VS Code Screenshot
- Manual-first practice (no built-ins before LINQ)
- graphify.js
- Restore Build Test Pipeline
- Build Command
- Clean Command
- Dotnet Clean Command
- Dotnet Lint Command
- Dotnet Publish Command
- Dotnet Run Command
- Format Command
- Lint Command
- Run Command
- Test Command
- Async console entry point with cancellation
- LINQ comparison kept beside manual version
- Records with pattern matching
- Second largest in one pass O(n)
- Fast path: query existing graph instead of rebuild
- Exercise edge-case tests with should_when naming
- xunit Moq Bogus FluentAssertions test stack
- MIT License Aslam Nazeer Shaikh
- Nested loops arrays and custom sorting
- String and character manipulation practice

## God Nodes (most connected - your core abstractions)
1. `StringDuplicationFiltering` - 25 edges
2. `Program` - 12 edges
3. `StringDuplicationFilteringTests` - 10 edges
4. `Graphify full pipeline (detect extract build cluster report)` - 9 edges
5. `SecondLargestNumberTests` - 8 edges
6. `permission` - 8 edges
7. `CSharpCodePractice.Tests` - 8 edges
8. `MethodKindsTests` - 7 edges
9. `CustomArraySorterTests` - 7 edges
10. `OpenCode Configuration` - 7 edges

## Surprising Connections (you probably didn't know these)
- `Practice basics without inbuilt methods` --conceptually_related_to--> `Manual-first practice (no built-ins before LINQ)`  [INFERRED]
  README.md → .opencode/skills/csharp-development.md
- `Graphify query path explain update workflow` --references--> `Graphify full pipeline (detect extract build cluster report)`  [EXTRACTED]
  AGENTS.md → .opencode/skills/graphify/SKILL.md
- `ClassCodeLibrary` --references--> `net10.0`  [EXTRACTED]
  ClassCodeLibrary/ClassCodeLibrary.csproj → MainConsoleApp/MainConsoleApp.csproj
- `ClassCodeLibrary` --references--> `Microsoft.NET.Sdk`  [EXTRACTED]
  ClassCodeLibrary/ClassCodeLibrary.csproj → MainConsoleApp/MainConsoleApp.csproj
- `CSharpCodePractice.Tests` --references--> `net10.0`  [EXTRACTED]
  CSharpCodePractice.Tests/CSharpCodePractice.Tests.csproj → MainConsoleApp/MainConsoleApp.csproj

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Single-slnx dotnet command suite** — _opencode_commands_build_build_command, _opencode_commands_test_test_command, _opencode_commands_run_run_command, _opencode_commands_clean_clean_command, _opencode_commands_lint_lint_command, _opencode_commands_format_format_command [EXTRACTED 1.00]
- **Graphify detect extract build query flow** — _opencode_skills_graphify_skill_full_pipeline, _opencode_skills_graphify_references_extraction_spec_extraction_rules, _opencode_skills_graphify_references_query_query_path_explain [EXTRACTED 1.00]
- **CSharpCodePractice agent team** — _opencode_agents_csharp_practice_assistant_csharp_practice_assistant, _opencode_agents_code_reviewer_code_reviewer, _opencode_agents_test_writer_test_writer, _opencode_agents_documentation_writer_documentation_writer [EXTRACTED 1.00]

## Communities (38 total, 22 thin omitted)

### Community 0 - "MethodKindsTests"
Cohesion: 0.11
Nodes (12): CancellationToken, Accumulator, Total, Adder, Calculator, IAdder, IntExtensions, Task (+4 more)

### Community 1 - "StringDuplicationFiltering"
Cohesion: 0.13
Nodes (3): StringDuplicationFiltering, ClassCodeLibrary.Strings.StringDuplicationFiltering, StringBuilder

### Community 2 - "Program"
Cohesion: 0.11
Nodes (12): Action, UniqueCharacterCounter, ClassCodeLibrary.Strings.UniqueCharacterCounter, CSharpCodePractice.Tests.Strings, ArgumentNullException, Fact, UniqueCharacterCounterTests, Demo (+4 more)

### Community 3 - "opencode.json"
Cohesion: 0.08
Nodes (24): agents, default, list, commands, custom, instructions, lsp, model (+16 more)

### Community 4 - ".FindSecondLargestNumber"
Cohesion: 0.21
Nodes (8): ArgumentException, SecondLargestNumber, ArgumentNullException, Fact, InlineData, Theory, SecondLargestNumberTests, InvalidOperationException

### Community 5 - ".FindVowels"
Cohesion: 0.21
Nodes (5): VowelsInUniqueCity, ClassCodeLibrary.Strings.VowelsInUniqueCity, ArgumentNullException, Fact, VowelsInUniqueCityTests

### Community 6 - ".SortWithBubbleSort"
Cohesion: 0.24
Nodes (7): CustomArraySorter, SortDirection, Ascending, Descending, ArgumentNullException, Fact, CustomArraySorterTests

### Community 7 - "StringDuplicationFilteringTests"
Cohesion: 0.22
Nodes (5): ArgumentNullException, Fact, InlineData, Theory, StringDuplicationFilteringTests

### Community 8 - "OpenCode Configuration"
Cohesion: 0.18
Nodes (12): Code Reviewer Agent, C# Practice Assistant Agent, Documentation Writer Agent, Test Writer Agent, Dotnet Build Command, Dotnet Test Command, C# Language Server csharp-ls, JSON Language Server (+4 more)

### Community 9 - "github"
Cohesion: 0.17
Nodes (12): enabled, headers, oauth, type, url, Authorization, mcp, github (+4 more)

### Community 10 - "Program.cs"
Cohesion: 0.24
Nodes (6): ClassCodeLibrary.Arrays.SecondLargestNumber, ClassCodeLibrary.Common, ClassCodeLibrary.Fundamentals.MethodKinds, ClassCodeLibrary.Arrays.CustomArraySorter, CSharpCodePractice.Tests.Arrays, MainConsoleApp

### Community 11 - "permission"
Cohesion: 0.18
Nodes (11): chmod 777 *, rm -rf *, sudo *, permission, bash, edit, glob, grep (+3 more)

### Community 12 - "Graphify full pipeline (detect extract build cluster report)"
Cohesion: 0.22
Nodes (10): Ingest URL and watch folder, Extra exports (wiki neo4j falkordb svg graphml mcp benchmark), Extraction rules (EXTRACTED INFERRED AMBIGUOUS, node IDs, confidence rubric), GitHub clone and cross-repo merge, Post-commit hook and CLAUDE.md integration, Query path explain with vocab expansion and save-result, Whisper transcription for video audio, Incremental update and cluster-only (+2 more)

### Community 13 - "CSharpCodePractice.Tests"
Cohesion: 0.33
Nodes (9): ClassCodeLibrary, CSharpCodePractice.Tests, MainConsoleApp, net10.0, Microsoft.NET.Sdk, coverlet.collector (6.0.4), Microsoft.NET.Test.Sdk (17.14.1), xunit (2.9.3) (+1 more)

### Community 14 - "VowelsInUniqueCity VS Code Screenshot"
Cohesion: 0.50
Nodes (5): Terminal console output listing City and Vowels per city, Program.cs demo harness with region-gated exercise calls, VowelsInUniqueCity VS Code Screenshot, VowelsInUniqueCity C# exercise, VS Code workspace layout with Explorer editor and terminal

### Community 15 - "Manual-first practice (no built-ins before LINQ)"
Cohesion: 0.67
Nodes (3): Manual-first practice (no built-ins before LINQ), CSharpCodePractice repo conventions and toolchain, Practice basics without inbuilt methods

## Knowledge Gaps
- **80 isolated node(s):** `Total`, `CSharpCodePractice.Tests.Fundamentals`, `MainConsoleApp`, `chmod 777 *`, `rm -rf *` (+75 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 110 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **22 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `Program` connect `Program` to `MethodKindsTests`, `Program.cs`, `.FindVowels`, `.SortWithBubbleSort`?**
  _High betweenness centrality (0.158) - this node is a cross-community bridge._
- **Why does `ClassCodeLibrary.Strings.StringDuplicationFiltering` connect `StringDuplicationFiltering` to `Program`, `Program.cs`?**
  _High betweenness centrality (0.134) - this node is a cross-community bridge._
- **What connects `Total`, `CSharpCodePractice.Tests.Fundamentals`, `MainConsoleApp` to the rest of the system?**
  _80 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `MethodKindsTests` be split into smaller, more focused modules?**
  _Cohesion score 0.1103448275862069 - nodes in this community are weakly interconnected._
- **Should `StringDuplicationFiltering` be split into smaller, more focused modules?**
  _Cohesion score 0.13227513227513227 - nodes in this community are weakly interconnected._
- **Should `Program` be split into smaller, more focused modules?**
  _Cohesion score 0.11333333333333333 - nodes in this community are weakly interconnected._
- **Should `opencode.json` be split into smaller, more focused modules?**
  _Cohesion score 0.08 - nodes in this community are weakly interconnected._