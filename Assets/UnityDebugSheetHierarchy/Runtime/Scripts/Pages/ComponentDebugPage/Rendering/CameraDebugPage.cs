using System.Collections.Generic;
using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Camera component properties
    /// </summary>
    public sealed class CameraDebugPage : ComponentDebugPageBase<Camera>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Camera.fieldOfView),
            nameof(Camera.nearClipPlane),
            nameof(Camera.farClipPlane),
            nameof(Camera.orthographic),
            nameof(Camera.orthographicSize),
            nameof(Camera.depth),
            nameof(Camera.clearFlags),
            nameof(Camera.backgroundColor),
            nameof(Camera.cullingMask),
        };
    }
}
