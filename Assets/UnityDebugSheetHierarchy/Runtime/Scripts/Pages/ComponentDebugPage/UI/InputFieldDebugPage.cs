using System.Collections.Generic;
using UnityEngine.UI;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying InputField component properties
    /// </summary>
    public sealed class InputFieldDebugPage : ComponentDebugPageBase<InputField>
    {
        /// <summary>
        /// List of properties that need real-time updates
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>
        {
            nameof(InputField.text),
            nameof(InputField.isFocused),
            nameof(InputField.caretPosition),
            nameof(InputField.selectionAnchorPosition),
            nameof(InputField.selectionFocusPosition),
            nameof(InputField.interactable),
            nameof(InputField.readOnly),
        };
    }
}
