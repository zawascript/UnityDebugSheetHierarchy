using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying AudioListener component properties
    /// </summary>
    public sealed class AudioListenerDebugPage : ComponentDebugPageBase<AudioListener>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(AudioListener.velocityUpdateMode),
        };
    }
}
