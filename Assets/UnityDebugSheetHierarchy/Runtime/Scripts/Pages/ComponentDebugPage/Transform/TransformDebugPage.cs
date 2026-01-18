using System.Collections;
using UnityDebugSheet.Runtime.Core.Scripts;
using UnityEngine;
#if UDS_USE_ASYNC_METHODS
using System.Threading.Tasks;
#endif

namespace DebugSheetHierarchy.Pages.ComponentDebugPage
{
    /// <summary>
    /// Debug page for displaying Transform information
    /// Local coordinates are editable, world coordinates are display-only
    /// </summary>
    public sealed class TransformDebugPage : DefaultDebugPageBase
    {
        private Transform _target;

        protected override string Title => _target != null
            ? $"Transform - {_target.name}"
            : "Transform";

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
            if (_target == null)
            {
                AddLabel("エラー: 対象が設定されていません", null);
#if UDS_USE_ASYNC_METHODS
                return Task.CompletedTask;
#else
                yield break;
#endif
            }

            // Local coordinate system (editable)
            AddLabel("Local Position", null, priority: 0);
            AddSlider(
                _target.localPosition.x,
                -100f,
                100f,
                "X",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var pos = _target.localPosition;
                        pos.x = value;
                        _target.localPosition = pos;
                    }
                },
                priority: 1
            );
            AddSlider(
                _target.localPosition.y,
                -100f,
                100f,
                "Y",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var pos = _target.localPosition;
                        pos.y = value;
                        _target.localPosition = pos;
                    }
                },
                priority: 2
            );
            AddSlider(
                _target.localPosition.z,
                -100f,
                100f,
                "Z",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var pos = _target.localPosition;
                        pos.z = value;
                        _target.localPosition = pos;
                    }
                },
                priority: 3
            );

            AddLabel("Local Rotation", null, priority: 10);
            AddSlider(
                _target.localRotation.eulerAngles.x,
                0f,
                360f,
                "X",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var euler = _target.localRotation.eulerAngles;
                        euler.x = value;
                        _target.localRotation = Quaternion.Euler(euler);
                    }
                },
                priority: 11
            );
            AddSlider(
                _target.localRotation.eulerAngles.y,
                0f,
                360f,
                "Y",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var euler = _target.localRotation.eulerAngles;
                        euler.y = value;
                        _target.localRotation = Quaternion.Euler(euler);
                    }
                },
                priority: 12
            );
            AddSlider(
                _target.localRotation.eulerAngles.z,
                0f,
                360f,
                "Z",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var euler = _target.localRotation.eulerAngles;
                        euler.z = value;
                        _target.localRotation = Quaternion.Euler(euler);
                    }
                },
                priority: 13
            );

            AddLabel("Local Scale", null, priority: 20);
            AddSlider(
                _target.localScale.x,
                0f,
                10f,
                "X",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var scale = _target.localScale;
                        scale.x = value;
                        _target.localScale = scale;
                    }
                },
                priority: 21
            );
            AddSlider(
                _target.localScale.y,
                0f,
                10f,
                "Y",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var scale = _target.localScale;
                        scale.y = value;
                        _target.localScale = scale;
                    }
                },
                priority: 22
            );
            AddSlider(
                _target.localScale.z,
                0f,
                10f,
                "Z",
                valueChanged: value =>
                {
                    if (_target != null)
                    {
                        var scale = _target.localScale;
                        scale.z = value;
                        _target.localScale = scale;
                    }
                },
                priority: 23
            );

            // World coordinate system (display-only)
            AddLabel("World Position", $"{_target.position.x:F3}, {_target.position.y:F3}, {_target.position.z:F3}", priority: 100);
            AddLabel("World Rotation", $"{_target.rotation.eulerAngles.x:F1}°, {_target.rotation.eulerAngles.y:F1}°, {_target.rotation.eulerAngles.z:F1}°", priority: 101);
            AddLabel("Lossy Scale", $"{_target.lossyScale.x:F3}, {_target.lossyScale.y:F3}, {_target.lossyScale.z:F3}", priority: 102);

#if UDS_USE_ASYNC_METHODS
            return Task.CompletedTask;
#else
            yield break;
#endif
        }
    }
}
