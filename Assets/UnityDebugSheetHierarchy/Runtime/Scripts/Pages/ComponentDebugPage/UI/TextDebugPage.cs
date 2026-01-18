using System.Collections.Generic;
using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Text component properties
    /// </summary>
    public sealed class TextDebugPage : ComponentDebugPageBase<Text>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Text.text),
            nameof(Text.font),
            nameof(Text.fontSize),
            nameof(Text.fontStyle),
            nameof(Text.color),
            nameof(Text.alignment),
            nameof(Text.alignByGeometry),
            nameof(Text.horizontalOverflow),
            nameof(Text.verticalOverflow),
            nameof(Text.lineSpacing),
            nameof(Text.supportRichText),
            nameof(Text.resizeTextForBestFit),
            nameof(Text.resizeTextMinSize),
            nameof(Text.resizeTextMaxSize),
        };
    }
}
