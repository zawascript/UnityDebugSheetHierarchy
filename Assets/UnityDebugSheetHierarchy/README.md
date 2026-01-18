# UnityDebugSheet Hierarchy Extension

[日本語](/Assets/UnityDebugSheetHierarchy/README_JA.md)

[![Unity](https://img.shields.io/badge/Unity-2020.3+-red.svg)](https://unity3d.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE.md)<br>
![ClaudeCode](https://img.shields.io/badge/Claude_Code-555?logo=claude)

An extension package for [UnityDebugSheet](https://github.com/Haruma-K/UnityDebugSheet) that enables runtime debugging and manipulation of Unity's hierarchy on DebugSheet.
Primarily intended for use with build artifacts (such as on-device testing) where HierarchyView is not available.

## Features

- **Hierarchy Visualization**: View Unity's scene hierarchy at runtime
- **GameObject Search**: Search GameObjects by name for quick access
- **Component Details**: Display list and properties of Components attached to each GameObject
- **Real-time Editing**: Edit properties of major Components like Transform, Rigidbody, UI elements during runtime
- **Extensive Component Support**: Supports 34+ Component types including Transform, Camera, Light, UI elements, Physics, Audio, Particles, and more

### Supported Components

- **Transform**: Transform, RectTransform
- **Rendering**: Camera, Light, MeshFilter, MeshRenderer, SpriteRenderer
- **Physics 3D**: Rigidbody, BoxCollider, CapsuleCollider, SphereCollider, MeshCollider, CharacterController
- **Physics 2D**: Rigidbody2D, BoxCollider2D, CircleCollider2D
- **UI**: Canvas, CanvasGroup, CanvasScaler, Image, RawImage, Button, Slider, Text, TextMeshProUGUI, Toggle, Dropdown, InputField, ScrollRect
- **Audio**: AudioSource, AudioListener
- **Animation**: Animation, Animator
- **Effects**: ParticleSystem

## Installation

### Via Unity Package Manager (Recommended)

1. Open Unity Editor
2. Select **Window > Package Manager**
3. Click **+** button and select **Add package from git URL**
4. Enter the following URL:
```
https://github.com/zawascript/UnityDebugSheetHierarchy.git?path=/Assets/UnityDebugSheetHierarchy
```

### Via manifest.json

Add the following to `dependencies` in `Packages/manifest.json`:

```json
{
  "dependencies": {
    "com.zawascript.unitydebugsheethierarchy": "https://github.com/zawascript/UnityDebugSheetHierarchy.git?path=/Assets/UnityDebugSheetHierarchy",
    "com.harumak.unitydebugsheet": "https://github.com/Haruma-K/UnityDebugSheet.git?path=/Assets/UnityDebugSheet"
  }
}
```

## Usage
You can use this package by simply adding `DebugSheetHierarchyPage`, `SceneHierarchyPage`, or `SearchPage` via DebugSheet's `AddPageLinkButton`.

### Page Descriptions
- **DebugSheetHierarchyPage**: Entry point to SceneHierarchyPage. Simply contains `PageLinkButton`s to `SceneHierarchyPage` and `SearchPage`.
- **SceneHierarchyPage**: Displays GameObject hierarchy in the scene
- **SearchPage**: Search by GameObject name
- **ComponentsPage**: List of Components on selected GameObject
- **Each ComponentDebugPage**: Display and edit detailed properties for each Component

## Creating Custom ComponentDebugPage

You can create custom ComponentDebugPages for your own Components by inheriting from `ComponentDebugPageBase<T>`.

### Basic Implementation

1. Create a new class inheriting from `ComponentDebugPageBase<T>` where `T` is your Component type
2. Override `UpdateTargetPropertyNames` to specify which properties should update in real-time

### Example

Suppose you have a custom component `HealthComponent`:

```csharp
using UnityEngine;

public class HealthComponent : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth = 100;
    public float regenerationRate = 1.0f;
    public bool isInvincible = false;
}
```

You can create a debug page for it like this:

```csharp
using System.Collections.Generic;
using DebugSheetHierarchy.Pages.ComponentDebugPage;

namespace YourNamespace
{
    public sealed class HealthComponentDebugPage : ComponentDebugPageBase<HealthComponent>
    {
        // Specify properties to update in real-time
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(HealthComponent.currentHealth),
            nameof(HealthComponent.isInvincible)
        };
    }
}
```

The page will automatically:
- Appear in the ComponentsPage when a GameObject has `HealthComponent`
- Display all public properties
- Update the specified properties (`currentHealth` and `isInvincible`) in real-time

**Note**: Properties not listed in `UpdateTargetPropertyNames` will only be displayed at page initialization. This is useful for performance when you only need certain properties to update dynamically.

## Requirements

- **Unity**: 2020.3 or later
- **Dependencies**: UnityDebugSheet 1.5.4 or later

## License

This project is published under the MIT License. See [LICENSE.md](LICENSE.md) for details.

## Credits

This package extends [UnityDebugSheet](https://github.com/Haruma-K/UnityDebugSheet) (by Haruki Yano). Deep gratitude for the wonderful features of UnityDebugSheet.

## For Developers

This repository is primarily developed using **Claude Code**. For detailed development guidelines, best practices, and architecture information, start Claude Code and ask questions directly.

### Issue-Based Development

We use Issue-Based Development workflow:

1. Create or find an issue for the feature/bug you want to work on
2. Start development with the `/gh-issue-dev <issue-number>` command
3. Claude Code will autonomously handle the implementation based on the issue
4. Follow the automated workflow to create branches, commits, and PRs

For more information on contributing, please refer to [CLAUDE.md](CLAUDE.md).

## Support

For issues or feature requests, please report to [GitHub Issues](https://github.com/zawascript/UnityDebugSheetHierarchy/issues).
