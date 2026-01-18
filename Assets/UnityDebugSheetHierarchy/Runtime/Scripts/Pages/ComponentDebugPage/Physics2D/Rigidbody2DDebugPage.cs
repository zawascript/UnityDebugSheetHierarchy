using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Rigidbody2D component properties
    /// </summary>
    public sealed class Rigidbody2DDebugPage : ComponentDebugPageBase<Rigidbody2D>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Rigidbody2D.mass),
            nameof(Rigidbody2D.gravityScale),
            nameof(Rigidbody2D.bodyType),
            nameof(Rigidbody2D.linearVelocity),
            nameof(Rigidbody2D.angularVelocity),
            nameof(Rigidbody2D.linearDamping),
            nameof(Rigidbody2D.angularDamping),
        };
    }
}
