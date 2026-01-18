using System.Collections;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine.SceneManagement;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

namespace DebugSheetHierarchy.Pages
{
    /// <summary>
    /// Page for displaying scene list
    /// Provides links to root objects of each scene
    /// </summary>
    public sealed class SceneHierarchyPage : DefaultDebugPageBase
    {
        protected override string Title => "Scene Hierarchy";
        
#if UDS_USE_ASYNC_METHODS
        public override Task Initialize()
#else
        public override IEnumerator Initialize()
#endif
        {
            // Get all currently loaded scenes
            var sceneCount = SceneManager.sceneCount;

            if (sceneCount == 0)
            {
                AddLabel("No scenes found", null);


#if UDS_USE_ASYNC_METHODS
                return Task.CompletedTask;
#else
                yield break;
#endif
            }

            for (var i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                DisplayScene(scene);
            }

            // Get and display DontDestroyOnLoad scene
            // Use reliable method of creating temporary GameObject to access scene
            var tempGo = new UnityEngine.GameObject("__TempDDOLHelper");
            UnityEngine.Object.DontDestroyOnLoad(tempGo);
            var dontDestroyOnLoadScene = tempGo.scene;
            UnityEngine.Object.Destroy(tempGo);

            // Verify that scene is valid and name is correct
            if (dontDestroyOnLoadScene.IsValid() &&
                dontDestroyOnLoadScene.name == "DontDestroyOnLoad" &&
                dontDestroyOnLoadScene.rootCount > 0)
            {
                DisplayScene(dontDestroyOnLoadScene);
            }


#if UDS_USE_ASYNC_METHODS
            return Task.CompletedTask;
#else
            yield break;
#endif
        }

        /// <summary>
        /// Display scene and its root objects
        /// </summary>
        private void DisplayScene(Scene scene)
        {
            // Display scene name as header
            AddLabel(
                $"Scene: {scene.name}",
                $"Loaded: {scene.isLoaded}, Path: {scene.path}"
            );

            if (!scene.isLoaded)
            {
                AddLabel("  (Scene is not loaded)", null);
                return;
            }

            // Get root objects of scene
            var rootObjects = scene.GetRootGameObjects();

            if (rootObjects.Length == 0)
            {
                AddLabel("  (No root objects)", null);
                return;
            }

            // Add links to each root object
            foreach (var rootObject in rootObjects)
            {
                if (rootObject == null) continue;

                var transform = rootObject.transform;
                AddPageLinkButton<HierarchyPage>(
                    $"  {rootObject.name}",
                    subText: $"Active: {rootObject.activeSelf}",
                    onLoad: x =>
                    {
                        var page = x.page as HierarchyPage;
                        page?.SetTarget(transform);
                    }
                );
            }
        }
    }
}
