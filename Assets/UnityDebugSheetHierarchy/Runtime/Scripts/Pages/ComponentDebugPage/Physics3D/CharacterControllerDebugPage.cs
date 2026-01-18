using System.Collections.Generic;
using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying CharacterController component properties
    /// </summary>
    public sealed class CharacterControllerDebugPage : ComponentDebugPageBase<CharacterController>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(CharacterController.isGrounded),
            nameof(CharacterController.velocity),
            nameof(CharacterController.collisionFlags),
            nameof(CharacterController.height),
            nameof(CharacterController.radius),
            nameof(CharacterController.center),
            nameof(CharacterController.slopeLimit),
            nameof(CharacterController.stepOffset),
            nameof(CharacterController.skinWidth),
            nameof(CharacterController.minMoveDistance),
            nameof(CharacterController.detectCollisions),
            nameof(CharacterController.enableOverlapRecovery),
        };
    }
}
