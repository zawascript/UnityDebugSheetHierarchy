using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying ScrollRect component properties
    /// </summary>
    public sealed class ScrollRectDebugPage : ComponentDebugPageBase<ScrollRect>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(ScrollRect.horizontal),
            nameof(ScrollRect.vertical),
            nameof(ScrollRect.movementType),
            nameof(ScrollRect.elasticity),
            nameof(ScrollRect.inertia),
            nameof(ScrollRect.decelerationRate),
            nameof(ScrollRect.scrollSensitivity),
            nameof(ScrollRect.horizontalNormalizedPosition),
            nameof(ScrollRect.verticalNormalizedPosition),
            nameof(ScrollRect.velocity),
            nameof(ScrollRect.content),
            nameof(ScrollRect.viewport),
            nameof(ScrollRect.horizontalScrollbar),
            nameof(ScrollRect.verticalScrollbar),
        };
    }
}
