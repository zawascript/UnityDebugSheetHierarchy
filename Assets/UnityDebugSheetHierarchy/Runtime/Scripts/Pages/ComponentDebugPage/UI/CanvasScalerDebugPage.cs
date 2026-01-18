using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying CanvasScaler component properties
    /// </summary>
    public sealed class CanvasScalerDebugPage : ComponentDebugPageBase<CanvasScaler>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(CanvasScaler.uiScaleMode),
            nameof(CanvasScaler.referenceResolution),
            nameof(CanvasScaler.matchWidthOrHeight),
            nameof(CanvasScaler.scaleFactor),
        };
    }
}
