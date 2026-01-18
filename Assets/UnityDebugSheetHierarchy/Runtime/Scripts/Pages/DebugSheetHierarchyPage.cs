using System.Collections;
using UnityDebugSheet.Runtime.Core.Scripts;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

namespace DebugSheetHierarchy.Pages
{
    /// <summary>
    /// Entry page for DebugSheetHierarchy
    /// Provides links to scene hierarchy and search functionality
    /// </summary>
    public sealed class DebugSheetHierarchyPage : DefaultDebugPageBase
    {
        protected override string Title => "Hierarchy";

#if UDS_USE_ASYNC_METHODS
        public override Task Initialize()
#else
        public override IEnumerator Initialize()
#endif
        {
            // Link to scene hierarchy page
            AddPageLinkButton<SceneHierarchyPage>(
                "Scene Hierarchy",
                subText: "Display scene hierarchy and object hierarchy"
            );

            // Link to search page
            AddPageLinkButton<SearchPage>(
                "Search",
                subText: "Search GameObject by name"
            );

#if UDS_USE_ASYNC_METHODS
            return Task.CompletedTask;
#else
                yield break;
#endif
        }
    }
}
