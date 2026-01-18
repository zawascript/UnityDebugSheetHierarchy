using System.Collections.Generic;

using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Slider component properties
    /// </summary>
    public sealed class SliderDebugPage : ComponentDebugPageBase<Slider>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Slider.value),
            nameof(Slider.minValue),
            nameof(Slider.maxValue),
            nameof(Slider.wholeNumbers),
            nameof(Slider.interactable),
        };
    }
}
