# UnityDebugSheet Hierarchy Extension

[English](/Assets/UnityDebugSheetHierarchy/README.md)

[![Unity](https://img.shields.io/badge/Unity-2020.3+-red.svg)](https://unity3d.com/)
[![License](https://img.shields.io/badge/license-MIT-green.svg)](LICENSE.md)<br>
![ClaudeCode](https://img.shields.io/badge/Claude_Code-555?logo=claude)

UnityのヒエラルキーをDebugSheet上でデバッグ表示・操作できる[UnityDebugSheet](https://github.com/Haruma-K/UnityDebugSheet)の拡張パッケージです。
主に、HierarchyViewの使えないビルド後の成果物（実機確認など）での利用を想定しています。

## 特徴

- **階層構造の可視化**: Unityのシーンヒエラルキーをランタイムで確認できます
- **Component詳細表示**: 各GameObjectにアタッチされているComponentの一覧とプロパティを表示
- **GameObject検索**: 名前でGameObjectを検索し、すぐにアクセス可能

### 対応済みComponent一覧

- **Transform系**: Transform, RectTransform
- **レンダリング**: Camera, Light, MeshFilter, MeshRenderer, SpriteRenderer
- **Physics 3D**: Rigidbody, BoxCollider, CapsuleCollider, SphereCollider, MeshCollider, CharacterController
- **Physics 2D**: Rigidbody2D, BoxCollider2D, CircleCollider2D
- **UI**: Canvas, CanvasGroup, CanvasScaler, Image, RawImage, Button, Slider, Text, TextMeshProUGUI, Toggle, Dropdown, InputField, ScrollRect
- **Audio**: AudioSource, AudioListener
- **Animation**: Animation, Animator
- **エフェクト**: ParticleSystem

## インストール方法

### Unity Package Manager経由（推奨）

1. Unity Editorを開く
2. **Window > Package Manager** を選択
3. **+** ボタンをクリックし、**Add package from git URL** を選択
4. 以下のURLを入力：
```
https://github.com/zawascript/UnityDebugSheetHierarchy.git?path=/Assets/UnityDebugSheetHierarchy
```

### manifest.json経由

`Packages/manifest.json`の`dependencies`に以下を追加：

```json
{
  "dependencies": {
    "com.zawascript.unitydebugsheethierarchy": "https://github.com/zawascript/UnityDebugSheetHierarchy.git?path=/Assets/UnityDebugSheetHierarchy",
    "com.harumak.unitydebugsheet": "https://github.com/Haruma-K/UnityDebugSheet.git?path=/Assets/UnityDebugSheet"
  }
}
```

## 使い方
`DebugSheetHierarchyPage` , `SceneHierarchyPage`,  `SearchPage` いずれかをDebugSheetの `AddPageLinkButton` で追加するだけで利用できます。

### ページの説明
- **DebugSheetHierarchyPage**: SceneHierarchyPageへのエントリーポイント。 `SceneHierarchyPage` と `SearchPage` への `PageLinkButton` が配置されているだけです。
- **SceneHierarchyPage**: シーン内のGameObject階層を表示
- **SearchPage**: GameObject名で検索
- **ComponentsPage**: 選択したGameObjectのComponent一覧
- **各ComponentDebugPage**: Componentごとの詳細プロパティ表示・編集

## 独自のComponentDebugPageを作成する

`ComponentDebugPageBase<T>`を継承することで、独自のComponentに対応したComponentDebugPageを作成できます。

### 基本的な実装方法

1. `ComponentDebugPageBase<T>`を継承した新しいクラスを作成（`T`は対象のComponentの型）
2. `UpdateTargetPropertyNames`をoverrideして、リアルタイム更新するプロパティを指定

### 実装例

例えば、以下のようなカスタムコンポーネント`HealthComponent`があるとします：

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

このコンポーネント用のデバッグページは以下のように作成できます：

```csharp
using System.Collections.Generic;
using DebugSheetHierarchy.Pages.ComponentDebugPage;

namespace YourNamespace
{
    public sealed class HealthComponentDebugPage : ComponentDebugPageBase<HealthComponent>
    {
        // リアルタイム更新するプロパティを指定
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(HealthComponent.currentHealth),
            nameof(HealthComponent.isInvincible)
        };
    }
}
```

これだけで、以下の機能が自動的に利用できるようになります：
- `HealthComponent`を持つGameObjectのComponentsPageに自動的に表示される
- すべてのpublicプロパティが表示される
- 指定したプロパティ（`currentHealth`と`isInvincible`）がリアルタイムで更新される

**注意**: `UpdateTargetPropertyNames`に指定しなかったプロパティは、ページの初期化時にのみ表示されます。動的に更新する必要のあるプロパティのみを指定することで、パフォーマンスを最適化できます。

## 動作環境

- **Unity**: 2020.3以降
- **依存パッケージ**: UnityDebugSheet 1.5.4以降

## ライセンス

このプロジェクトはMITライセンスの下で公開されています。詳細は[LICENSE.md](LICENSE.md)を参照してください。

## クレジット

このパッケージは[UnityDebugSheet](https://github.com/Haruma-K/UnityDebugSheet)（by Haruki Yano）を拡張したものです。UnityDebugSheetの素晴らしい機能に深く感謝いたします。


## サポート

問題や機能要望がある場合は、[GitHubのIssues](https://github.com/zawascript/UnityDebugSheetHierarchy/issues)にご報告ください。
