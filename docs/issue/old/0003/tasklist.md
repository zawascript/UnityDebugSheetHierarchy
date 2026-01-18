# Issue #3: ComponentDebugPageの拡充

## 現在のステップ
- [x] ステップ1: Issueの内容を理解する
- [x] ステップ2: mainブランチをpull
- [x] ステップ3: issue/3ブランチを作成
- [x] ステップ4: タスクの洗い出し
- [x] ステップ5: ユーザーの承認を得る
- [x] ステップ6: 実装を進める
- [ ] ステップ7: 動作確認を依頼
- [ ] ステップ8: コミット作成
- [ ] ステップ9: PR作成

---

## 既存のComponentDebugPage（22個）

### Transform / Core
- TransformDebugPage
- RectTransformDebugPage

### Rendering
- CameraDebugPage
- LightDebugPage
- MeshRendererDebugPage
- SpriteRendererDebugPage

### UI (uGUI)
- CanvasDebugPage
- CanvasGroupDebugPage
- CanvasScalerDebugPage
- ImageDebugPage
- RawImageDebugPage
- ButtonDebugPage
- SliderDebugPage
- TextMeshProUGUIDebugPage

### Physics 3D
- RigidbodyDebugPage
- BoxColliderDebugPage
- CharacterControllerDebugPage（未コミット）

### Physics 2D
- Rigidbody2DDebugPage

### Audio
- AudioSourceDebugPage
- AudioListenerDebugPage

### Animation
- AnimatorDebugPage
- AnimationDebugPage

### Effects
- ParticleSystemDebugPage

---

## 追加候補のコンポーネント一覧

### フェーズ1: 高優先度（頻出かつ実用性が高い）

| コンポーネント | カテゴリ | 優先度 | 理由 |
|--------------|---------|-------|------|
| **Text (Legacy)** | UI | 高 | TextMeshProを使わないプロジェクトでまだ使用される |
| **Toggle** | UI | 高 | フォーム系UIで頻出 |
| **InputField** | UI | 高 | フォーム系UIで頻出 |
| **Dropdown** | UI | 高 | フォーム系UIで頻出 |
| **ScrollRect** | UI | 高 | スクロール可能なUIで必須 |
| **SphereCollider** | Physics 3D | 高 | BoxColliderと並んで頻出 |
| **CapsuleCollider** | Physics 3D | 高 | キャラクターで頻出 |
| **MeshCollider** | Physics 3D | 高 | 複雑な形状のコリジョンで必須 |
| **BoxCollider2D** | Physics 2D | 高 | 2Dゲームで最も頻出 |
| **CircleCollider2D** | Physics 2D | 高 | 2Dゲームで頻出 |

### フェーズ2: 中優先度（よく使われるが特定のユースケース）

| コンポーネント | カテゴリ | 優先度 | 理由 |
|--------------|---------|-------|------|
| **SkinnedMeshRenderer** | Rendering | 中 | キャラクターモデルで必須 |
| **LineRenderer** | Rendering | 中 | デバッグ表示やエフェクトで使用 |
| **TrailRenderer** | Rendering | 中 | エフェクトで使用 |
| **ReflectionProbe** | Rendering | 中 | リアルタイム反射に使用 |
| **LayoutGroup (Horizontal/Vertical/Grid)** | UI | 中 | UI配置で頻出 |
| **ContentSizeFitter** | UI | 中 | 動的サイズUIで使用 |
| **Mask / RectMask2D** | UI | 中 | UIクリッピングで使用 |
| **Scrollbar** | UI | 中 | ScrollRectと組み合わせて使用 |
| **NavMeshAgent** | AI/Navigation | 中 | ナビゲーションで使用 |
| **NavMeshObstacle** | AI/Navigation | 中 | 動的障害物で使用 |
| **CapsuleCollider2D** | Physics 2D | 中 | 2Dキャラクターで使用 |
| **PolygonCollider2D** | Physics 2D | 中 | 複雑な2Dコリジョンで使用 |
| **Joint系 (HingeJoint, SpringJoint等)** | Physics | 中 | 物理シミュレーションで使用 |

### フェーズ3: 低優先度（特定のケースで使用）

| コンポーネント | カテゴリ | 優先度 | 理由 |
|--------------|---------|-------|------|
| **VideoPlayer** | Media | 低 | 動画再生時のみ使用 |
| **Terrain** | Rendering | 低 | 地形ゲームで使用 |
| **LODGroup** | Rendering | 低 | 最適化で使用 |
| **OcclusionArea / OcclusionPortal** | Rendering | 低 | 特定の最適化で使用 |
| **WindZone** | Effects | 低 | 特定のエフェクトで使用 |
| **Cloth** | Physics | 低 | 布シミュレーションで使用 |
| **WheelCollider** | Physics | 低 | 車両シミュレーションで使用 |
| **ConstantForce** | Physics | 低 | 特定の物理演出で使用 |
| **EventSystem** | UI | 低 | シーンに1つだが確認用途 |
| **GraphicRaycaster** | UI | 低 | Canvasと連携 |

---

## 実装計画

### フェーズ1（高優先度）の実装順序

1. **UI系**
   - [x] TextDebugPage
   - [x] ToggleDebugPage
   - [x] InputFieldDebugPage
   - [x] DropdownDebugPage
   - [x] ScrollRectDebugPage

2. **Physics 3D系**
   - [x] SphereColliderDebugPage
   - [x] CapsuleColliderDebugPage
   - [x] MeshColliderDebugPage

3. **Physics 2D系**
   - [x] BoxCollider2DDebugPage
   - [x] CircleCollider2DDebugPage

### フェーズ2以降
フェーズ1完了後、ユーザーの要望に応じて追加実装を検討

---

## 承認状況
- [x] ユーザー承認済み（2026-01-15）
