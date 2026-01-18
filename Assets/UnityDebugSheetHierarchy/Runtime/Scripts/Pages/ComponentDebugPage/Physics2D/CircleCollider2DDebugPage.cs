using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying CircleCollider2D component properties
    /// </summary>
    public sealed class CircleCollider2DDebugPage : ComponentDebugPageBase<CircleCollider2D>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(CircleCollider2D.radius),
            nameof(CircleCollider2D.offset),
            nameof(CircleCollider2D.isTrigger),
            nameof(CircleCollider2D.usedByEffector),
            nameof(CircleCollider2D.usedByComposite),
            nameof(CircleCollider2D.enabled),
        };
    }
}
