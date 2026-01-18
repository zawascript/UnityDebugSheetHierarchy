using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using DebugSheetHierarchy.Pages.ComponentDebugPage;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

namespace DebugSheetHierarchy.Pages
{
    /// <summary>
    /// Page for displaying list of components attached to specified Transform
    /// Links to dedicated debug page for supported components
    /// Automatically detects pages inheriting from ComponentDebugPageBase
    /// </summary>
    public sealed class ComponentsPage : DefaultDebugPageBase
    {
        private Transform _target;
        private static Dictionary<Type, Type> _componentToPageTypeMap;

        protected override string Title => _target != null
            ? $"Components - {_target.name}"
            : "Components";

        /// <summary>
        /// Sets the Transform to be displayed
        /// </summary>
        public void SetTarget(Transform target)
        {
            _target = target;
        }

        /// <summary>
        /// Searches for all pages inheriting from ComponentDebugPageBase and
        /// builds mapping from component types to page types
        /// </summary>
        private static void BuildComponentToPageTypeMap()
        {
            if (_componentToPageTypeMap != null) return;

            _componentToPageTypeMap = new Dictionary<Type, Type>();

            // Get all types from current assembly
            var assembly = Assembly.GetExecutingAssembly();
            var allTypes = assembly.GetTypes();

            foreach (var type in allTypes)
            {
                // Check if inheriting from ComponentDebugPageBase<>
                if (type.IsAbstract || !type.IsClass) continue;

                var baseType = type.BaseType;
                while (baseType != null)
                {
                    if (baseType.IsGenericType &&
                        baseType.GetGenericTypeDefinition() == typeof(ComponentDebugPageBase<>))
                    {
                        // Get generic type argument (TComponent)
                        var componentType = baseType.GetGenericArguments()[0];
                        _componentToPageTypeMap[componentType] = type;
                        break;
                    }
                    baseType = baseType.BaseType;
                }
            }
        }


#if UDS_USE_ASYNC_METHODS
        public override Task Initialize()
#else
        public override IEnumerator Initialize()
#endif
        {
            // Build component → page mapping
            BuildComponentToPageTypeMap();

            var gameObject = _target.gameObject;
            var components = gameObject.GetComponents<Component>();

            if (components.Length == 0)
            {
                AddLabel("No components", null);

#if UDS_USE_ASYNC_METHODS
                return Task.CompletedTask;
#else
                yield break;
#endif
            }

            AddLabel($"Components : {components.Length}", null, priority: 0);

            var priority = 10;
            foreach (var component in components)
            {
                if (component == null) continue;

                var componentType = component.GetType();
                var typeName = componentType.Name;

                // Search for page type corresponding to component type
                Type pageType = null;
                var currentType = componentType;

                // Search up inheritance hierarchy for corresponding page
                while (currentType != null && pageType == null)
                {
                    if (_componentToPageTypeMap.TryGetValue(currentType, out pageType))
                    {
                        break;
                    }
                    currentType = currentType.BaseType;
                }

                if (pageType != null)
                {
                    // Add link if corresponding page is found
                    AddComponentPageLink(component, typeName, pageType, priority++);
                }
                else
                {
                    // Display name only if no corresponding page exists
                    AddLabel(
                        typeName,
                        $"Type: {componentType.FullName}",
                        priority: priority++
                    );
                }
            }

#if UDS_USE_ASYNC_METHODS
            return Task.CompletedTask;
#else
            yield break;
#endif
        }

        /// <summary>
        /// Adds link to component debug page
        /// </summary>
        private void AddComponentPageLink(Component component, string displayName, Type pageType, int priority)
        {
            // Create onLoad action
            Action<(string pageId, DebugPageBase page)> onLoadAction = x =>
            {
                // Call SetTarget method
                var setTargetMethod = pageType.GetMethod("SetTarget");
                setTargetMethod?.Invoke(x.page, new object[] { component });
            };

            // Use non-generic version of AddPageLinkButton
            // By passing pageType as type parameter, correct page type instance is created
            AddPageLinkButton(
                pageType,           // pageType
                displayName,        // text
                "Show details",        // subText
                null,               // textColor
                null,               // subTextColor
                null,               // icon
                null,               // iconColor
                null,               // titleOverride
                onLoadAction,       // onLoad
                null,               // pageId
                priority            // priority
            );
        }
    }
}
