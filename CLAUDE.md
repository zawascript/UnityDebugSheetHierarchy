# CLAUDE.md

This file provides guidance to Claude Code (claude.ai/code) when working with code in this repository.

## Communication Guidelines

**Language Policy:**
- **User Communication**: Always respond to users in the same language they use. If a user writes in Japanese, respond in Japanese. If they write in English, respond in English.
- **Issue Communication**: When posting comments to GitHub Issues using `gh issue comment`, follow the same language as the user's communication in that issue thread.
- **Code and Documentation**: All code deliverables (source code, comments, commit messages, PR descriptions, etc.) must be written in English, regardless of the conversation language.

**Examples:**
- User asks in Japanese → Respond in Japanese, but write code/comments in English
- User asks in English → Respond in English, write code/comments in English
- Issue thread is in Japanese → Post comments in Japanese, but implementation remains in English

## Project Overview

UnityDebugSheet Hierarchy Extension - A Unity package that extends [UnityDebugSheet](https://github.com/Haruma-K/UnityDebugSheet) to provide runtime hierarchy visualization and component debugging capabilities.

**Key Features:**
- Runtime visualization of Unity scene hierarchy
- GameObject search by name
- Component inspection and real-time property editing
- Support for 29+ Unity component types (Transform, Camera, Light, UI, Physics, Audio, Particles, etc.)

## Development Environment

- **Unity Version**: 2020.3 or later
- **Required Dependency**: UnityDebugSheet 1.5.4+
- **Package Name**: `com.zawascript.unitydebugsheethierarchy`
- **Language**: C#

## Architecture

### Page Navigation System

The package uses UnityDebugSheet's page-based navigation system. Pages inherit from `DefaultDebugPageBase` or `PropertyListDebugPageBase` and are navigated using `AddPageLinkButton<T>()`.

**Page Flow:**
```
DebugSheetHierarchyPage (Entry)
  → SceneHierarchyPage (Shows all scenes)
    → HierarchyPage (Individual GameObject)
      → ComponentsPage (Lists all components)
        → ComponentDebugPage<T> (Component-specific properties)
      → TransformDebugPage (Transform properties)

SearchPage (Parallel entry - searches all scenes)
  → HierarchyPage (Matching GameObjects)
```

### Component Debug Page Architecture

**Automatic Component-to-Page Mapping:**
- `ComponentsPage` uses reflection to build a `Dictionary<Type, Type>` mapping component types to their debug page types
- It searches for all classes inheriting from `ComponentDebugPageBase<T>`
- The generic type parameter `T` determines which component type the page handles
- This allows automatic discovery - adding a new `ComponentDebugPageBase<SomeComponent>` automatically makes it available

**Base Classes:**
- `ComponentDebugPageBase<TComponent>`: Base for all component debug pages
  - Provides `SetTarget(TComponent)` method
  - Exposes `UpdateTargetPropertyNames` for real-time property updates
  - Uses `PropertyListDebugPageBase` for automatic property display via reflection

### Conditional Compilation

**⚠️ IMPORTANT: Required Preprocessor Directives for Pages**

When creating new pages under `Pages/`, you must handle these preprocessor directives:

#### 1. `UDS_USE_ASYNC_METHODS` (Required for all pages with Initialize())

All pages that override `Initialize()` must support both async and coroutine patterns:

```csharp
using System.Collections;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

public sealed class MyPage : DefaultDebugPageBase
{
#if UDS_USE_ASYNC_METHODS
    public override Task Initialize()
#else
    public override IEnumerator Initialize()
#endif
    {
        // ... page initialization code ...

#if UDS_USE_ASYNC_METHODS
        return Task.CompletedTask;
#else
        yield break;
#endif
    }
}
```

For early returns (e.g., error handling):
```csharp
if (errorCondition)
{
#if UDS_USE_ASYNC_METHODS
    return Task.CompletedTask;
#else
    yield break;
#endif
}
```

#### 2. `EXCLUDE_UNITY_DEBUG_SHEET` (Handled at assembly level)

This symbol excludes all debug sheet code from compilation. It's already configured in `UnityDebugSheetHierarchy.asmdef` via `defineConstraints`:
```json
"defineConstraints": ["!EXCLUDE_UNITY_DEBUG_SHEET"]
```

**No per-file handling is needed** - the entire assembly is excluded when this symbol is defined.

#### 3. `TEXTMESHPRO_PRESENT` (For TMP-dependent code only)

TextMeshPro support is optional:
- `TextMeshProUGUIDebugPage.cs` uses `#if TEXTMESHPRO_PRESENT` directive
- The package detects TMP availability at compile time
- No manual configuration needed for projects with/without TMP

## Common Development Tasks

### Adding Support for a New Component Type

**When working with Cloud Code:** Use the `create-component-debug-page` subagent, which will auto-generate a ComponentDebugPage from your Unity component type.

1. Create a new file in `Assets/UnityDebugSheetHierarchy/Runtime/Scripts/Pages/ComponentDebugPage/`
2. Inherit from `ComponentDebugPageBase<TComponent>`:

```csharp
namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    public sealed class MyComponentDebugPage : ComponentDebugPageBase<MyComponent>
    {
        // Optional: Specify properties that should update in real-time
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(MyComponent.someProperty),
            nameof(MyComponent.anotherProperty)
        };
    }
}
```

3. The page will automatically be detected and available in ComponentsPage - no registration needed

4. **Add a test GameObject to the Demo scene** (when using the `create-component-debug-page` agent):
   - The agent will automatically use the MCP tool to create a GameObject with the component
   - The GameObject will be placed under `DemoScene/Components/[Category]/[ComponentTypeName]`
   - Categories: UI, Rendering, Physics, Audio, Animation, Transform, Other

> **Note:** `ComponentDebugPageBase<T>` handles `UDS_USE_ASYNC_METHODS` internally, so subclasses don't need preprocessor directives. However, if you create a custom page inheriting directly from `DefaultDebugPageBase` and override `Initialize()`, you must follow the pattern described in [Conditional Compilation](#conditional-compilation).

### Demo Scene GameObject Creation Tool

This project includes an MCP tool for automatically adding test GameObjects to the Demo scene:

**MCP Tool:** `mcp__unity-natural-mcp__DemoSceneObjectCreator__CreateGameObjectWithComponent`

**Parameters:**
- `componentTypeName` (string): Fully qualified component type name (e.g., "UnityEngine.UI.Image", "UnityEngine.Light")
- `category` (string): Component category for organization (UI, Rendering, Physics, Audio, Animation, Transform, Other)

**Example usage:**
```
CreateGameObjectWithComponent(
  componentTypeName="UnityEngine.UI.Image",
  category="UI"
)
```

**GameObject hierarchy:**
```
DemoScene
└── Components
    └── [Category]
        └── [ComponentTypeName]
```

The tool:
- Automatically opens the Demo scene if not already open
- Creates the hierarchy structure (Components/Category) if needed
- Adds the specified component to the GameObject
- Saves the scene after creation

### Issue-Based Development Workflow

This project uses `gh-issue-dev` command for issue-based development:

**Starting work on an issue:**
```bash
gh issue dev <issue-number>
```

This command will:
- Create a new branch for the issue
- Set up the development environment
- Link commits to the issue automatically

**Workflow:**
1. Find or create an issue for the feature/bug
2. Run `gh issue dev <issue-number>` to start working
3. Make your changes and commit regularly
4. Push and create a PR when ready
5. The PR will be automatically linked to the issue

**Communication with User:**
- If you have questions or need clarification during development, post them as comments on the GitHub issue using `gh issue comment <issue-number>`
- Always start your comment with `**CLAUDE CODE から送信**` to clearly indicate it's from Claude Code
- Wait for user responses in the issue comments before proceeding with unclear implementation details

## Key Implementation Details

### Scene Traversal

The package handles both normal scenes and DontDestroyOnLoad:
- `SceneHierarchyPage` and `SearchPage` create a temporary GameObject, call `DontDestroyOnLoad()`, access its scene reference, then destroy it
- This is the reliable method to access the DontDestroyOnLoad scene at runtime

### Page Initialization Pattern

All pages implement `Initialize()` method:
- Returns `IEnumerator` (coroutine) or `Task` depending on `UDS_USE_ASYNC_METHODS` symbol
- See [Conditional Compilation](#conditional-compilation) for the required preprocessor pattern
- Use `AddLabel()`, `AddSwitch()`, `AddSlider()`, `AddPageLinkButton<T>()` to build UI
- `priority` parameter controls display order
- Call `Reload()` to refresh UI after dynamic changes (like search results)

### TransformDebugPage vs ComponentDebugPageBase

`TransformDebugPage` is intentionally a `DefaultDebugPageBase` (not `ComponentDebugPageBase<Transform>`):
- It provides custom sliders for position/rotation/scale editing
- Shows read-only world coordinates
- Offers better UX than automatic property reflection
- Linked directly from `HierarchyPage` as a special case

## Repository Structure

The repository contains three main directories under `Assets/`:

### Assets/Demo/
- **Purpose**: Demo and testing directory for repository cloning
- **Contents**: Sample scenes and testing materials to verify package functionality
- **Usage**: Used to test and demonstrate the package features when someone clones this repository

### Assets/UnityDebugSheetHierarchy/
- **Purpose**: Distributable package directory
- **Distribution**: Published as a Git package via Unity Package Manager
- **Important**: This directory must be self-contained and work independently
- **Restriction**: Do not include Demo-scene-specific code or dependencies here

### Assets/UnityNaturalMCPTools/
- **Purpose**: Development tools for this project
- **Contents**: UnityNaturalMCP tool collection used during development
- **Usage**: Tools that facilitate development workflow and automation