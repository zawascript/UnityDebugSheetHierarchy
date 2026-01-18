using System.Collections.Generic;

using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying ParticleSystem component properties
    /// </summary>
    public sealed class ParticleSystemDebugPage : ComponentDebugPageBase<ParticleSystem>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(ParticleSystem.isPlaying),
            nameof(ParticleSystem.isPaused),
            nameof(ParticleSystem.particleCount),
            nameof(ParticleSystem.time),
            nameof(ParticleSystem.randomSeed),
        };
    }
}
