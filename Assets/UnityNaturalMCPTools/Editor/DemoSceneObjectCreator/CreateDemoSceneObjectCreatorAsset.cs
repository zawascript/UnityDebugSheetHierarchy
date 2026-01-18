using UnityEditor;
using UnityEngine;

namespace UnityDebugSheetHierarchy.Editor.MCP
{
    public static class CreateDemoSceneObjectCreatorAsset
    {
        private const string AssetPath = "Assets/UnityNaturalMCPTools/Editor/DemoSceneObjectCreator/DemoSceneObjectCreatorBuilder.asset";

        [InitializeOnLoadMethod]
        private static void AutoCreateAssetIfNeeded()
        {
            // Auto-create asset on editor load if it doesn't exist
            var existingAsset = AssetDatabase.LoadAssetAtPath<DemoSceneObjectCreatorBuilder>(AssetPath);
            if (existingAsset == null)
            {
                CreateAsset();
            }
        }

        [MenuItem("Tools/UnityDebugSheetHierarchy/Create Demo Scene Object Creator Builder Asset")]
        public static void CreateAsset()
        {
            // Check if asset already exists
            var existingAsset = AssetDatabase.LoadAssetAtPath<DemoSceneObjectCreatorBuilder>(AssetPath);
            if (existingAsset != null)
            {
                Debug.LogWarning($"Asset already exists at {AssetPath}");
                return;
            }

            // Create the ScriptableObject
            var asset = ScriptableObject.CreateInstance<DemoSceneObjectCreatorBuilder>();

            // Save it as an asset
            AssetDatabase.CreateAsset(asset, AssetPath);
            AssetDatabase.SaveAssets();
            AssetDatabase.Refresh();

            Debug.Log($"Created DemoSceneObjectCreatorBuilder asset at {AssetPath}");
            Debug.Log("Please refresh MCP server: Edit > Project Settings > Unity Natural MCP > Refresh");
        }
    }
}
