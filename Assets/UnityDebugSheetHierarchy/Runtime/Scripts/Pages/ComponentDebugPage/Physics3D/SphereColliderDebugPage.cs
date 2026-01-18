using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying SphereCollider component properties
    /// </summary>
    public sealed class SphereColliderDebugPage : ComponentDebugPageBase<SphereCollider>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(SphereCollider.center),
            nameof(SphereCollider.radius),
            nameof(SphereCollider.isTrigger),
            nameof(SphereCollider.enabled),
        };
    }
}
