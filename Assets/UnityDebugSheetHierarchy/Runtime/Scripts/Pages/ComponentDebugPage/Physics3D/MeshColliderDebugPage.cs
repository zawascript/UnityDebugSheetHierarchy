using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying MeshCollider component properties
    /// </summary>
    public sealed class MeshColliderDebugPage : ComponentDebugPageBase<MeshCollider>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(MeshCollider.sharedMesh),
            nameof(MeshCollider.convex),
            nameof(MeshCollider.isTrigger),
            nameof(MeshCollider.cookingOptions),
            nameof(MeshCollider.enabled),
            nameof(MeshCollider.bounds),
            nameof(MeshCollider.material),
            nameof(MeshCollider.sharedMaterial),
        };
    }
}
