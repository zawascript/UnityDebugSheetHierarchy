using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying CapsuleCollider component properties
    /// </summary>
    public sealed class CapsuleColliderDebugPage : ComponentDebugPageBase<CapsuleCollider>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(CapsuleCollider.center),
            nameof(CapsuleCollider.radius),
            nameof(CapsuleCollider.height),
            nameof(CapsuleCollider.direction),
            nameof(CapsuleCollider.isTrigger),
            nameof(CapsuleCollider.enabled),
        };
    }
}
