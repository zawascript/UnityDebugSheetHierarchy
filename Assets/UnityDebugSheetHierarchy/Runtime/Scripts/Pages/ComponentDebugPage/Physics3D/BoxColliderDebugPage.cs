using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying BoxCollider component properties
    /// </summary>
    public sealed class BoxColliderDebugPage : ComponentDebugPageBase<BoxCollider>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(BoxCollider.center),
            nameof(BoxCollider.size),
            nameof(BoxCollider.isTrigger),
            nameof(BoxCollider.enabled),
        };
    }
}
