using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying AudioSource component properties
    /// </summary>
    public sealed class AudioSourceDebugPage : ComponentDebugPageBase<AudioSource>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(AudioSource.clip),
            nameof(AudioSource.volume),
            nameof(AudioSource.pitch),
            nameof(AudioSource.loop),
            nameof(AudioSource.playOnAwake),
            nameof(AudioSource.isPlaying),
            nameof(AudioSource.time),
        };
    }
}
