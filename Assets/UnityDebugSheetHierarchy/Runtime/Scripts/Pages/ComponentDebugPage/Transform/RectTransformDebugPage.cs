using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying RectTransform component properties
    /// </summary>
    public sealed class RectTransformDebugPage : ComponentDebugPageBase<RectTransform>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(RectTransform.anchoredPosition),
            nameof(RectTransform.sizeDelta),
            nameof(RectTransform.pivot),
            nameof(RectTransform.anchorMin),
            nameof(RectTransform.anchorMax),
            nameof(RectTransform.offsetMin),
            nameof(RectTransform.offsetMax),
        };
    }
}
