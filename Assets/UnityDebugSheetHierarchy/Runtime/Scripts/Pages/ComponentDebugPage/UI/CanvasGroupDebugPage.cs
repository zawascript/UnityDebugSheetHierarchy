using System.Collections.Generic;
using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying CanvasGroup component properties
    /// </summary>
    public sealed class CanvasGroupDebugPage : ComponentDebugPageBase<CanvasGroup>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(CanvasGroup.alpha),
            nameof(CanvasGroup.interactable),
            nameof(CanvasGroup.blocksRaycasts),
            nameof(CanvasGroup.ignoreParentGroups),
        };
    }
}
