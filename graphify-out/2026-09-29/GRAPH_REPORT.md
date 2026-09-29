# Graph Report - C-Sharp-Material  (2026-09-29)

## Corpus Check
- 52 files · ~32,554 words
- Verdict: corpus is large enough that graph structure adds value.

## Summary
- 173 nodes · 162 edges · 35 communities (13 shown, 22 thin omitted)
- Extraction: 94% EXTRACTED · 6% INFERRED · 0% AMBIGUOUS · INFERRED: 9 edges (avg confidence: 0.85)
- Token cost: 0 input · 0 output

## Graph Freshness
- Built from commit: `551f7e0c`
- Run `git rev-parse HEAD` and compare to check if the graph is stale.
- Run `graphify update .` after code changes (no API cost).

## Community Hubs (Navigation)
- OpenCode Project Config
- Exercise Entry Points
- Manual Dedup Methods
- Agent Command Suite
- MCP GitHub Integration
- LINQ Dedup Methods
- Permission Guardrails
- Graphify Pipeline Docs
- Manual-First Practice
- Solution Project Structure
- Custom Array Sorter
- Vowels City Exercise
- Model Configuration
- Exercise Screenshot Evidence
- Vowel Test Strategy
- Second Largest Pattern
- Bubble Sort Notes
- Graphify Reminder Plugin
- CI Build Pipeline
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
- Records Pattern Matching
- Graph Query Fast Path
- Edge Case Test Naming
- Generic Ordering Semantics
- MIT License
- String Practice Focus

## God Nodes (most connected - your core abstractions)
1. `StringDuplicationFiltering` - 15 edges
2. `StringDuplicationFilteringLinq` - 11 edges
3. `Graphify full pipeline (detect extract build cluster report)` - 9 edges
4. `permission` - 8 edges
5. `OpenCode Configuration` - 7 edges
6. `github` - 6 edges
7. `project` - 4 edges
8. `bash` - 4 edges
9. `ui-skills` - 4 edges
10. `CustomArraySorter` - 4 edges

## Surprising Connections (you probably didn't know these)
- `Practice basics without inbuilt methods` --conceptually_related_to--> `Manual-first practice (no built-ins before LINQ)`  [INFERRED]
  README.md → .opencode/skills/csharp-development.md
- `Nested loops arrays and custom sorting` --conceptually_related_to--> `Custom Bubble Sort O(n^2)`  [INFERRED]
  README.md → ClassCodeLibrary/CustomArraySorter/CustomArraySorter.md
- `Graphify query path explain update workflow` --references--> `Graphify full pipeline (detect extract build cluster report)`  [EXTRACTED]
  AGENTS.md → .opencode/skills/graphify/SKILL.md
- `Async console entry point with cancellation` --references--> `FindVowels manual vowel scan`  [EXTRACTED]
  .opencode/skills/csharp-development.md → ClassCodeLibrary/VowelsInUniqueCity/VowelsInUniqueCity.md
- `xunit Moq Bogus FluentAssertions test stack` --references--> `FindVowels manual vowel scan`  [EXTRACTED]
  .opencode/skills/testing-strategy.md → ClassCodeLibrary/VowelsInUniqueCity/VowelsInUniqueCity.md

## Import Cycles
- None detected.

## Hyperedges (group relationships)
- **Single-slnx dotnet command suite** — _opencode_commands_build_build_command, _opencode_commands_test_test_command, _opencode_commands_run_run_command, _opencode_commands_clean_clean_command, _opencode_commands_lint_lint_command, _opencode_commands_format_format_command [EXTRACTED 1.00]
- **Graphify detect extract build query flow** — _opencode_skills_graphify_skill_full_pipeline, _opencode_skills_graphify_references_extraction_spec_extraction_rules, _opencode_skills_graphify_references_query_query_path_explain [EXTRACTED 1.00]
- **Manual-first exercise pattern across notes** — classcodelibrary_customarraysorter_customarraysorter_bubble_sort, classcodelibrary_stringduplicationfiltering_stringduplicationfiltering_manual_dedup, classcodelibrary_uniquecharactercounter_uniquecharactercounter_ascii_counting [EXTRACTED 1.00]
- **CSharpCodePractice agent team** — _opencode_agents_csharp_practice_assistant_csharp_practice_assistant, _opencode_agents_code_reviewer_code_reviewer, _opencode_agents_test_writer_test_writer, _opencode_agents_documentation_writer_documentation_writer [EXTRACTED 1.00]

## Communities (35 total, 22 thin omitted)

### Community 0 - "OpenCode Project Config"
Cohesion: 0.11
Nodes (18): agents, default, list, commands, custom, instructions, lsp, model (+10 more)

### Community 1 - "Exercise Entry Points"
Cohesion: 0.12
Nodes (7): SecondLargestNumber, UniqueCharacterCounter, ClassCodeLibrary.SecondLargestNumber, ClassCodeLibrary.StringDuplicationFiltering, ClassCodeLibrary.UniqueCharacterCounter, MainConsoleApp, Program

### Community 3 - "Agent Command Suite"
Cohesion: 0.18
Nodes (12): Code Reviewer Agent, C# Practice Assistant Agent, Documentation Writer Agent, Test Writer Agent, Dotnet Build Command, Dotnet Test Command, C# Language Server csharp-ls, JSON Language Server (+4 more)

### Community 4 - "MCP GitHub Integration"
Cohesion: 0.17
Nodes (12): enabled, headers, oauth, type, url, Authorization, mcp, github (+4 more)

### Community 6 - "Permission Guardrails"
Cohesion: 0.18
Nodes (11): chmod 777 *, rm -rf *, sudo *, permission, bash, edit, glob, grep (+3 more)

### Community 7 - "Graphify Pipeline Docs"
Cohesion: 0.22
Nodes (10): Ingest URL and watch folder, Extra exports (wiki neo4j falkordb svg graphml mcp benchmark), Extraction rules (EXTRACTED INFERRED AMBIGUOUS, node IDs, confidence rubric), GitHub clone and cross-repo merge, Post-commit hook and CLAUDE.md integration, Query path explain with vocab expansion and save-result, Whisper transcription for video audio, Incremental update and cluster-only (+2 more)

### Community 8 - "Manual-First Practice"
Cohesion: 0.29
Nodes (7): LINQ comparison kept beside manual version, Manual-first practice (no built-ins before LINQ), CSharpCodePractice repo conventions and toolchain, Manual string deduplication without LINQ collections, LINQ reference (Distinct Where GroupBy Select Char helpers), ASCII array character counting O(n) O(1), Practice basics without inbuilt methods

### Community 9 - "Solution Project Structure"
Cohesion: 0.33
Nodes (4): net10.0, Microsoft.NET.Sdk, net10.0, Microsoft.NET.Sdk

### Community 12 - "Model Configuration"
Cohesion: 0.33
Nodes (6): muse-spark-1.3-contributor-free, options, models, reasoningEffort, provider, opencode

### Community 13 - "Exercise Screenshot Evidence"
Cohesion: 0.50
Nodes (5): Terminal console output listing City and Vowels per city, Program.cs demo harness with region-gated exercise calls, VowelsInUniqueCity VS Code Screenshot, VowelsInUniqueCity C# exercise, VS Code workspace layout with Explorer editor and terminal

### Community 14 - "Vowel Test Strategy"
Cohesion: 0.50
Nodes (4): Async console entry point with cancellation, xunit Moq Bogus FluentAssertions test stack, FindVowels manual vowel scan, RemoveDuplicates for city array

### Community 15 - "Second Largest Pattern"
Cohesion: 0.67
Nodes (3): Second largest in one pass O(n), SortGivenArray generic method with sortOrder flag, FindSecondLargest single traversal O(n) O(1)

### Community 16 - "Bubble Sort Notes"
Cohesion: 0.67
Nodes (3): Custom Bubble Sort O(n^2), Inbuilt sorting with Array.Sort, Nested loops arrays and custom sorting

## Knowledge Gaps
- **81 isolated node(s):** `$schema`, `version`, `model`, `small_model`, `reasoningEffort` (+76 more)
  These have ≤1 connection - possible missing edges or undocumented components. (Counts symbols only; 96 node(s) total have ≤1 connection when file, concept and rationale nodes are included.)
- **22 thin communities (<3 nodes) omitted from report** — run `graphify query` to explore isolated nodes.

## Suggested Questions
_Questions this graph is uniquely positioned to answer:_

- **Why does `StringDuplicationFiltering` connect `Manual Dedup Methods` to `Exercise Entry Points`?**
  _High betweenness centrality (0.040) - this node is a cross-community bridge._
- **Why does `StringDuplicationFilteringLinq` connect `LINQ Dedup Methods` to `Exercise Entry Points`?**
  _High betweenness centrality (0.032) - this node is a cross-community bridge._
- **What connects `$schema`, `version`, `model` to the rest of the system?**
  _81 weakly-connected nodes found - possible documentation gaps or missing edges._
- **Should `OpenCode Project Config` be split into smaller, more focused modules?**
  _Cohesion score 0.10526315789473684 - nodes in this community are weakly interconnected._
- **Should `Exercise Entry Points` be split into smaller, more focused modules?**
  _Cohesion score 0.125 - nodes in this community are weakly interconnected._