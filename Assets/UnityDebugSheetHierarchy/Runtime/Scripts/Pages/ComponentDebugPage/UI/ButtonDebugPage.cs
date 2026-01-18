using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Button component properties
    /// </summary>
    public sealed class ButtonDebugPage : ComponentDebugPageBase<Button>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Button.interactable),
            nameof(Button.transition),
            nameof(Button.targetGraphic),
        };
    }
}
