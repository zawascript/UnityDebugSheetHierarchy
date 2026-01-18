using UnityEngine;
#if !EXCLUDE_UNITY_DEBUG_SHEET
using UnityDebugSheet.Runtime.Core.Scripts;
using DebugSheetHierarchy.Pages;
#endif

namespace DebugSheetHierarchy
{
    /// <summary>
    /// Class for initializing DebugSheetHierarchy
    /// Place in scene to initialize DebugSheet
    /// </summary>
    public class DebugSheetHierarchyInitializer : MonoBehaviour
    {
        [SerializeField]
        [Tooltip("DebugSheetを自動的に初期化するかどうか")]
        private bool autoInitialize = true;

        [SerializeField]
        [Tooltip("初期化時に表示するページ（DebugSheetHierarchyPageまたはSceneHierarchyPageを推奨）")]
        private InitialPageType initialPage = InitialPageType.DebugSheetHierarchyPage;

        private void Start()
        {
            if (autoInitialize)
            {
                InitializeDebugSheet();
            }
        }

        /// <summary>
        /// Initializes DebugSheet
        /// </summary>
        public void InitializeDebugSheet()
        {
#if !EXCLUDE_UNITY_DEBUG_SHEET
            switch (initialPage)
            {
                case InitialPageType.DebugSheetHierarchyPage:
                    DebugSheet.Instance.Initialize<DebugSheetHierarchyPage>();
                    break;

                case InitialPageType.SceneHierarchyPage:
                    DebugSheet.Instance.Initialize<SceneHierarchyPage>();
                    break;

                case InitialPageType.SearchPage:
                    DebugSheet.Instance.Initialize<SearchPage>();
                    break;
            }
#endif

            Debug.Log("[DebugSheetHierarchy] 初期化完了");
        }

        /// <summary>
        /// Type of initial page
        /// </summary>
        private enum InitialPageType
        {
            DebugSheetHierarchyPage,
            SceneHierarchyPage,
            SearchPage
        }
    }
}
