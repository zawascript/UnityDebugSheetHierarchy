using System.Collections.Generic;
using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying CanvasRenderer component properties
    /// </summary>
    public sealed class CanvasRendererDebugPage : ComponentDebugPageBase<CanvasRenderer>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(CanvasRenderer.cull),
            nameof(CanvasRenderer.hasMoved),
            nameof(CanvasRenderer.absoluteDepth),
            nameof(CanvasRenderer.relativeDepth),
            nameof(CanvasRenderer.hasRectClipping),
            nameof(CanvasRenderer.materialCount),
        };
    }
}
