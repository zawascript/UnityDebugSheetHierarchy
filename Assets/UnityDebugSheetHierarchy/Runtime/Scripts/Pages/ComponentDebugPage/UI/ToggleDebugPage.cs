using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Toggle component properties
    /// </summary>
    public sealed class ToggleDebugPage : ComponentDebugPageBase<Toggle>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Toggle.isOn),
            nameof(Toggle.interactable),
            nameof(Toggle.transition),
            nameof(Toggle.toggleTransition),
            nameof(Toggle.graphic),
            nameof(Toggle.group),
        };
    }
}
