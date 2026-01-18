using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Light component properties
    /// </summary>
    public sealed class LightDebugPage : ComponentDebugPageBase<Light>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Light.type),
            nameof(Light.color),
            nameof(Light.intensity),
            nameof(Light.range),
            nameof(Light.spotAngle),
            nameof(Light.shadows),
            nameof(Light.shadowStrength),
            nameof(Light.cullingMask),
        };
    }
}
