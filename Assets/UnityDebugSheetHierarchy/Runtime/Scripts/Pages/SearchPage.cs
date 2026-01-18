using System.Collections;
using System.Collections.Generic;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
using UnityEngine.SceneManagement;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

namespace DebugSheetHierarchy.Pages
{
    /// <summary>
    /// Page for searching GameObjects by name
    /// Supports both exact and partial matching, displaying search results as links to HierarchyPage
    /// </summary>
    public sealed class SearchPage : DefaultDebugPageBase
    {
        private const int SearchResultPriorityStart = 100;
        private int _currentSearchResultItemId = -1;

        protected override string Title => "Search";
        
#if UDS_USE_ASYNC_METHODS
        public override Task Initialize()
#else
        public override IEnumerator Initialize()
#endif
        {
            // Add search field
            AddSearchField(
                placeholder: "Enter GameObject name",
                submitted: OnSearchSubmitted,
                priority: 0
            );

            AddLabel("Search results will be displayed here", null, priority: 10);


#if UDS_USE_ASYNC_METHODS
            return Task.CompletedTask;
#else
            yield break;
#endif
        }

        /// <summary>
        /// Handler for when search is executed
        /// </summary>
        private void OnSearchSubmitted(string searchText)
        {
            // Clear previous search results
            ClearSearchResults();

            if (string.IsNullOrWhiteSpace(searchText))
            {
                AddLabel("Please enter search text", null, priority: SearchResultPriorityStart);
                Reload();
                return;
            }

            // Search for GameObjects from all scenes
            var results = SearchGameObjects(searchText);

            if (results.Count == 0)
            {
                AddLabel($" 「{searchText}」 not found.", null, priority: SearchResultPriorityStart);
            }
            else
            {
                AddLabel($"Results: {results.Count}", null, priority: SearchResultPriorityStart);

                var priority = SearchResultPriorityStart + 1;
                foreach (var result in results)
                {
                    if (result.transform == null) continue;

                    AddPageLinkButton<HierarchyPage>(
                        result.name,
                        subText: $"Scene: {result.sceneName}",
                        onLoad: x =>
                        {
                            var page = x.page as HierarchyPage;
                            page?.SetTarget(result.transform);
                        },
                        priority: priority++
                    );
                }
            }

            // Rebuild UI
            Reload();
        }

        /// <summary>
        /// Delete previous search results
        /// </summary>
        private void ClearSearchResults()
        {
            // Delete all items with priority higher than SearchResultPriorityStart
            // Note: Since DebugPageBase does not have a priority-based deletion method,
            // use the method of clearing all and re-adding the search field
            ClearItems();

            // Re-add search field
            AddSearchField(
                placeholder: "Enter the name of the GameObject",
                submitted: OnSearchSubmitted,
                priority: 0
            );
        }

        /// <summary>
        /// Search for GameObjects from all scenes
        /// </summary>
        private List<SearchResult> SearchGameObjects(string searchText)
        {
            var results = new List<SearchResult>();
            var sceneCount = SceneManager.sceneCount;

            // Search from normal scenes
            for (var i = 0; i < sceneCount; i++)
            {
                var scene = SceneManager.GetSceneAt(i);
                if (!scene.isLoaded) continue;

                var rootObjects = scene.GetRootGameObjects();
                foreach (var rootObject in rootObjects)
                {
                    if (rootObject == null) continue;

                    // Recursively search root object and its descendants
                    SearchInHierarchy(rootObject.transform, searchText, scene.name, results);
                }
            }

            // Search from DontDestroyOnLoad scene
            // Use reliable method of creating temporary GameObject to access scene
            var tempGo = new GameObject("__TempDDOLHelper");
            Object.DontDestroyOnLoad(tempGo);
            var dontDestroyOnLoadScene = tempGo.scene;
            Object.Destroy(tempGo);

            // Verify that scene is valid and name is correct
            if (dontDestroyOnLoadScene.IsValid() &&
                dontDestroyOnLoadScene.name == "DontDestroyOnLoad" &&
                dontDestroyOnLoadScene.isLoaded)
            {
                var rootObjects = dontDestroyOnLoadScene.GetRootGameObjects();
                foreach (var rootObject in rootObjects)
                {
                    if (rootObject == null) continue;

                    // Recursively search root object and its descendants
                    SearchInHierarchy(rootObject.transform, searchText, "DontDestroyOnLoad", results);
                }
            }

            return results;
        }

        /// <summary>
        /// Recursively search Transform hierarchy
        /// </summary>
        private void SearchInHierarchy(Transform transform, string searchText, string sceneName, List<SearchResult> results)
        {
            if (transform == null) return;

            // Search by exact or partial match
            if (transform.name.Equals(searchText) ||
                transform.name.Contains(searchText))
            {
                results.Add(new SearchResult
                {
                    transform = transform,
                    name = transform.name,
                    sceneName = sceneName
                });
            }

            // Recursively search child objects
            for (var i = 0; i < transform.childCount; i++)
            {
                SearchInHierarchy(transform.GetChild(i), searchText, sceneName, results);
            }
        }

        /// <summary>
        /// Structure for storing search results
        /// </summary>
        private struct SearchResult
        {
            public Transform transform;
            public string name;
            public string sceneName;
        }
    }
}
