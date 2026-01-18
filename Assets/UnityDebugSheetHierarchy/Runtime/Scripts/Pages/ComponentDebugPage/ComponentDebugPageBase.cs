using System.Collections.Generic;
using System.Reflection;
using UnityDebugSheet.Runtime.Extensions.Unity;
using UnityEngine;

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Base class for component debug pages
    /// Inherits from PropertyListDebugPageBase and provides common functionality
    /// </summary>
    /// <typeparam name="TComponent">Target component type</typeparam>
    public abstract class ComponentDebugPageBase<TComponent> : PropertyListDebugPageBase<TComponent>
        where TComponent : Component
    {
        protected TComponent Target;

        protected override string Title => typeof(TComponent).Name;

        /// <summary>
        /// Sets BindingFlags to display instance properties
        /// </summary>
        public override BindingFlags BindingFlags =>
            BindingFlags.Public | BindingFlags.Instance;

        /// <summary>
        /// Returns the instance to be displayed
        /// </summary>
        public override object TargetObject => Target;

        /// <summary>
        /// Sets the target component to be displayed
        /// </summary>
        public virtual void SetTarget(TComponent component)
        {
            Target = component;
        }

        /// <summary>
        /// List of properties that need real-time updates
        /// Override in derived classes to add necessary properties
        /// </summary>
        public override List<string> UpdateTargetPropertyNames { get; } = new List<string>();
    }
}
