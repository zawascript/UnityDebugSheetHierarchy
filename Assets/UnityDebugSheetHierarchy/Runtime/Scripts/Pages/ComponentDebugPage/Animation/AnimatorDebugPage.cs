using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Animator component properties
    /// </summary>
    public sealed class AnimatorDebugPage : ComponentDebugPageBase<Animator>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(Animator.speed),
            nameof(Animator.cullingMode),
            nameof(Animator.updateMode),
            nameof(Animator.applyRootMotion),
            nameof(Animator.enabled),
        };
    }
}
