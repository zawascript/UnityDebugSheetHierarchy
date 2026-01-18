using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying GraphicRaycaster component properties
    /// </summary>
    public sealed class GraphicRaycasterDebugPage : ComponentDebugPageBase<GraphicRaycaster>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(GraphicRaycaster.ignoreReversedGraphics),
            nameof(GraphicRaycaster.blockingObjects),
            nameof(GraphicRaycaster.blockingMask),
        };
    }
}
