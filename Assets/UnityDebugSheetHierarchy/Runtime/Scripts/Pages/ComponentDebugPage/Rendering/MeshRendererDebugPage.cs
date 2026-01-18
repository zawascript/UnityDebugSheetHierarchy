using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying MeshRenderer component properties
    /// </summary>
    public sealed class MeshRendererDebugPage : ComponentDebugPageBase<MeshRenderer>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(MeshRenderer.receiveShadows),
            nameof(MeshRenderer.shadowCastingMode),
            nameof(MeshRenderer.lightProbeUsage),
            nameof(MeshRenderer.reflectionProbeUsage),
            nameof(MeshRenderer.sortingOrder),
            nameof(MeshRenderer.sortingLayerID),
        };
    }
}
