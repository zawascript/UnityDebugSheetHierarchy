using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying MeshFilter component properties
    /// </summary>
    public sealed class MeshFilterDebugPage : ComponentDebugPageBase<MeshFilter>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(MeshFilter.mesh),
            nameof(MeshFilter.sharedMesh),
        };
    }
}
