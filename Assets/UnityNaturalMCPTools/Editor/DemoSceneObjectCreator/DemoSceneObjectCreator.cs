using System;
using System.ComponentModel;
using System.Threading;
using ModelContextProtocol.Server;
using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace UnityDebugSheetHierarchy.Editor.MCP
{
    [McpServerToolType]
    [Description("Create GameObjects with components in the Demo scene for testing ComponentDebugPages")]
    public class DemoSceneObjectCreator
    {
        private const string DemoScenePath = "Assets/Demo/Scenes/DemoScene.unity";
        private const string ComponentsRootName = "Components";

        [McpServerTool]
        [Description("Create a GameObject with the specified component in the Demo scene. The GameObject will be created under 'Components/Category/ComponentTypeName' hierarchy.")]
        public string CreateGameObjectWithComponent(
            [Description("The full type name of the component (e.g., 'UnityEngine.UI.Image', 'UnityEngine.Light')")]
            string componentTypeName,
            [Description("The category name for organizing components (e.g., 'UI', 'Rendering', 'Physics')")]
            string category)
        {
            // Validate inputs
            if (string.IsNullOrEmpty(componentTypeName))
            {
                return "Error: componentTypeName cannot be null or empty";
            }

            if (string.IsNullOrEmpty(category))
            {
                return "Error: category cannot be null or empty";
            }

            // Execute on main thread and wait for result
            string result = null;
            var resetEvent = new ManualResetEvent(false);

            EditorApplication.delayCall += () =>
            {
                try
                {
                    result = CreateGameObjectOnMainThread(componentTypeName, category);
                }
                catch (Exception ex)
                {
                    Debug.LogError($"DemoSceneObjectCreator error: {ex.Message}\n{ex.StackTrace}");
                    result = $"Error: {ex.Message}";
                }
                finally
                {
                    resetEvent.Set();
                }
            };

            resetEvent.WaitOne();
            return result;
        }

        private string CreateGameObjectOnMainThread(string componentTypeName, string category)
        {
            // Open Demo scene
            var scene = EditorSceneManager.OpenScene(DemoScenePath);
            if (!scene.IsValid())
            {
                return $"Error: Failed to open scene at {DemoScenePath}";
            }

            // Get or create "Components" root GameObject
            var componentsRoot = GameObject.Find(ComponentsRootName);
            if (componentsRoot == null)
            {
                componentsRoot = new GameObject(ComponentsRootName);
            }

            // Get or create category GameObject under Components
            Transform categoryTransform = componentsRoot.transform.Find(category);
            GameObject categoryObject;
            if (categoryTransform == null)
            {
                categoryObject = new GameObject(category);
                categoryObject.transform.SetParent(componentsRoot.transform);
            }
            else
            {
                categoryObject = categoryTransform.gameObject;
            }

            // Get component type using reflection
            Type componentType = Type.GetType(componentTypeName);
            if (componentType == null)
            {
                // Try with UnityEngine assembly qualified name
                componentType = Type.GetType($"{componentTypeName}, UnityEngine");
            }

            if (componentType == null)
            {
                // Try with UnityEngine.UI assembly qualified name
                componentType = Type.GetType($"{componentTypeName}, UnityEngine.UI");
            }

            if (componentType == null)
            {
                return $"Error: Component type '{componentTypeName}' not found. Please use fully qualified type name (e.g., 'UnityEngine.UI.Image')";
            }

            // Extract simple type name for GameObject name
            string gameObjectName = componentType.Name;

            // Check if GameObject with this component already exists
            Transform existingTransform = categoryObject.transform.Find(gameObjectName);
            if (existingTransform != null)
            {
                return $"GameObject '{gameObjectName}' already exists under {ComponentsRootName}/{category}";
            }

            // Create GameObject with the component
            GameObject newGameObject = new GameObject(gameObjectName);
            newGameObject.transform.SetParent(categoryObject.transform);

            // Add component using reflection
            UnityEngine.Component addedComponent = newGameObject.AddComponent(componentType);
            if (addedComponent == null)
            {
                GameObject.DestroyImmediate(newGameObject);
                return $"Error: Failed to add component of type '{componentTypeName}'";
            }

            // Save the scene
            EditorSceneManager.SaveScene(scene);

            return $"Success: Created GameObject '{gameObjectName}' with {componentType.Name} component at {ComponentsRootName}/{category}/{gameObjectName}";
        }
    }
}
