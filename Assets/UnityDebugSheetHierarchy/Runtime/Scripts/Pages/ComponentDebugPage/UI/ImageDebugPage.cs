using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Image component properties
    /// </summary>
    public sealed class ImageDebugPage : ComponentDebugPageBase<Image>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Image.sprite),
            nameof(Image.color),
            nameof(Image.raycastTarget),
            nameof(Image.type),
            nameof(Image.fillAmount),
            nameof(Image.preserveAspect),
        };
    }
}
