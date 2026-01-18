using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying BoxCollider2D component properties
    /// </summary>
    public sealed class BoxCollider2DDebugPage : ComponentDebugPageBase<BoxCollider2D>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(BoxCollider2D.offset),
            nameof(BoxCollider2D.size),
            nameof(BoxCollider2D.edgeRadius),
            nameof(BoxCollider2D.autoTiling),
            nameof(BoxCollider2D.isTrigger),
            nameof(BoxCollider2D.usedByEffector),
            nameof(BoxCollider2D.usedByComposite),
            nameof(BoxCollider2D.enabled),
        };
    }
}
