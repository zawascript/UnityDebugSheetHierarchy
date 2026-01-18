using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Dropdown component properties
    /// </summary>
    public sealed class DropdownDebugPage : ComponentDebugPageBase<Dropdown>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Dropdown.value),
            nameof(Dropdown.options),
            nameof(Dropdown.captionText),
            nameof(Dropdown.captionImage),
            nameof(Dropdown.itemText),
            nameof(Dropdown.itemImage),
            nameof(Dropdown.interactable),
            nameof(Dropdown.transition),
        };
    }
}
