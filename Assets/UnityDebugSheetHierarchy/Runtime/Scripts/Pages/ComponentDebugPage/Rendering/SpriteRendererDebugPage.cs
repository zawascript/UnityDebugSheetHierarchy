using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying SpriteRenderer component properties
    /// </summary>
    public sealed class SpriteRendererDebugPage : ComponentDebugPageBase<SpriteRenderer>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(SpriteRenderer.sprite),
            nameof(SpriteRenderer.color),
            nameof(SpriteRenderer.flipX),
            nameof(SpriteRenderer.flipY),
            nameof(SpriteRenderer.sortingOrder),
            nameof(SpriteRenderer.sortingLayerID),
            nameof(SpriteRenderer.drawMode),
        };
    }
}
