using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Rigidbody component properties
    /// </summary>
    public sealed class RigidbodyDebugPage : ComponentDebugPageBase<Rigidbody>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Rigidbody.mass),
            nameof(Rigidbody.linearDamping),
            nameof(Rigidbody.angularDamping),
            nameof(Rigidbody.useGravity),
            nameof(Rigidbody.isKinematic),
            nameof(Rigidbody.linearVelocity),
            nameof(Rigidbody.angularVelocity),
        };
    }
}
