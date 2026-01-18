#if UDSH_TMPPRO
using System.Collections.Generic;
using TMPro;


namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying TextMeshProUGUI component properties
    /// </summary>
    public sealed class TextMeshProUGUIDebugPage : ComponentDebugPageBase<TextMeshProUGUI>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(TextMeshProUGUI.text),
            nameof(TextMeshProUGUI.fontSize),
            nameof(TextMeshProUGUI.color),
            nameof(TextMeshProUGUI.alignment),
            nameof(TextMeshProUGUI.fontStyle),
            nameof(TextMeshProUGUI.enableAutoSizing),
        };
    }
}
#endif
