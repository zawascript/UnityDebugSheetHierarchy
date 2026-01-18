using System.Collections.Generic;
using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Canvas component properties
    /// </summary>
    public sealed class CanvasDebugPage : ComponentDebugPageBase<Canvas>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Canvas.renderMode),
            nameof(Canvas.sortingOrder),
            nameof(Canvas.scaleFactor),
            nameof(Canvas.referencePixelsPerUnit),
            nameof(Canvas.pixelPerfect),
        };
    }
}
