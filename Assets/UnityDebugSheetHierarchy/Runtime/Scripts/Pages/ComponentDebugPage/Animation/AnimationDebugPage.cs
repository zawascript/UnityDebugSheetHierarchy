using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Animation component properties
    /// </summary>
    public sealed class AnimationDebugPage : ComponentDebugPageBase<Animation>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Animation.clip),
            nameof(Animation.playAutomatically),
            nameof(Animation.wrapMode),
            nameof(Animation.isPlaying),
        };
    }
}
