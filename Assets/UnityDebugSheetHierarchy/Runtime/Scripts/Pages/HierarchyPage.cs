using System.Collections;
using DebugSheetHierarchy.Pages.ComponentDebugPage;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

namespace DebugSheetHierarchy.Pages
{
    /// <summary>
    /// Page for displaying information of specified Transform
    /// Displays GameObject info, active toggle, component list, and child object list
    /// </summary>
    public sealed class HierarchyPage : DefaultDebugPageBase
    {
        private Transform _target;

        protected override string Title => _target != null ? _target.name : "Hierarchy";

        /// <summary>
        /// Sets the Transform to be displayed
        /// </summary>
        public void SetTarget(Transform target)
        {
            _target = target;
        }
        
#if UDS_USE_ASYNC_METHODS
        public override Task Initialize()
#else
        public override IEnumerator Initialize()
#endif
        {
            var gameObject = _target.gameObject;

            // Hierarchy path and tag/layer information
            AddLabel(
                GetHierarchyPath(_target),
                $"Tag: {gameObject.tag} | Layer: {LayerMask.LayerToName(gameObject.layer)}",
                priority: 0
            );

            // Active/inactive toggle switch
            AddSwitch(
                value: gameObject.activeSelf,
                text: "Active",
                valueChanged: value =>
                {
                    if (_target != null && _target.gameObject != null)
                    {
                        _target.gameObject.SetActive(value);
                    }
                },
                priority: 10
            );

            // Link to Transform information page
            AddPageLinkButton<TransformDebugPage>(
                "Transform",
                subText: "Details such as Position, Rotation, Scale",
                onLoad: x =>
                {
                    var page = x.page as TransformDebugPage;
                    page?.SetTarget(_target);
                },
                priority: 20
            );

            // Link to Components page
            AddPageLinkButton<ComponentsPage>(
                "Components",
                subText: "List of attached components",
                onLoad: x =>
                {
                    var page = x.page as ComponentsPage;
                    page?.SetTarget(_target);
                },
                priority: 30
            );

            // Children section
            AddLabel("Children", null, priority: 40);

            var childCount = _target.childCount;
            if (childCount == 0)
            {
                AddLabel(" There are no child objects", null, priority: 41);
            }
            else
            {
                for (var i = 0; i < childCount; i++)
                {
                    var child = _target.GetChild(i);
                    if (child == null) continue;

                    AddPageLinkButton<HierarchyPage>(
                        $"  {child.name}",
                        subText: $"Active: {child.gameObject.activeSelf}",
                        onLoad: x =>
                        {
                            var page = x.page as HierarchyPage;
                            page?.SetTarget(child);
                        },
                        priority: 50 + i
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
        /// Gets hierarchy path of Transform
        /// </summary>
        private string GetHierarchyPath(Transform transform)
        {
            if (transform == null) return "";

            var path = transform.name;
            var parent = transform.parent;

            while (parent != null)
            {
                path = parent.name + "/" + path;
                parent = parent.parent;
            }

            return path;
        }
    }
}
