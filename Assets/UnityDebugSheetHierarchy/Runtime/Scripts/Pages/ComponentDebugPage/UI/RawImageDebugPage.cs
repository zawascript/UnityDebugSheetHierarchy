using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying RawImage component properties
    /// </summary>
    public sealed class RawImageDebugPage : ComponentDebugPageBase<RawImage>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(RawImage.texture),
            nameof(RawImage.color),
            nameof(RawImage.raycastTarget),
            nameof(RawImage.uvRect),
        };
    }
}
