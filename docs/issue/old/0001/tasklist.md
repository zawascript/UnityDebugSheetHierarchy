# Issue #1: EXCLUDE_UNITY_DEBUG_SHEETに対応

## 現在のステップ
**Phase 1: Assembly Definition の修正** - 完了
**Phase 2: 動作確認** - 確認待ち

## 問題の概要
UnityDebugSheetは `EXCLUDE_UNITY_DEBUG_SHEET` シンボルを使用してすべてのコードをコンパイルから除外できるが、UnityDebugSheetHierarchyはこれに対応していない。

## 実装方針

### Phase 1: Assembly Definition (asmdef) の修正
UnityDebugSheet本体と同様に、`EXCLUDE_UNITY_DEBUG_SHEET` シンボルが定義されている場合にアセンブリ全体をコンパイルから除外する。

**タスク:**
1. `UnityDebugSheetHierarchy.asmdef` に `defineConstraints` フィールドを追加
   - 条件: `!EXCLUDE_UNITY_DEBUG_SHEET` (シンボルが定義されていない場合のみコンパイル)
   - これにより、シンボルが定義されているとアセンブリ全体が無効化される

### Phase 2: 動作確認
1. `EXCLUDE_UNITY_DEBUG_SHEET` シンボルが未定義の状態でコンパイルが通ることを確認
2. `EXCLUDE_UNITY_DEBUG_SHEET` シンボルを定義した状態でコンパイルエラーが出ないことを確認
3. Demoシーンでの動作確認

## 技術的詳細

### defineConstraints とは
Unity Assembly Definition の機能で、特定のシンボルが定義されているかどうかに基づいてアセンブリのコンパイルを制御できる。

- `"SYMBOL"`: シンボルが定義されている場合のみコンパイル
- `"!SYMBOL"`: シンボルが定義されていない場合のみコンパイル

### 参考実装
UnityDebugSheet本体も同様の仕組みを使用しており、Player Settingsの Scripting Define Symbols に `EXCLUDE_UNITY_DEBUG_SHEET` を追加することで、すべてのデバッグシートコードをリリースビルドから除外できる。

## 修正ファイル
- `Assets/UnityDebugSheetHierarchy/Runtime/Scripts/UnityDebugSheetHierarchy.asmdef`

## 参考資料
- [UnityDebugSheet GitHub](https://github.com/Haruma-K/UnityDebugSheet)
- [UnityDebugSheet README (日本語)](https://github.com/Haruma-K/UnityDebugSheet/blob/master/README_JA.md)
- [Unity Assembly Definition Files Tutorial](https://letsmakeagame.net/assembly-definition-files-tutorial/)

## 承認状況
- [x] Phase 1の実装方針について承認済み (2026-01-15)
- [x] Phase 2の動作確認手順について承認済み (2026-01-15)
