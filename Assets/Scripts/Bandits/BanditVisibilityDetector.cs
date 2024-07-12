using System;
using System.Collections.Generic;
using MIG.API;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif

namespace MIG.Bandits
{
    public sealed class BanditVisibilityDetector : MonoBehaviour, IVisibilityDetector
    {
        [SerializeField]
        private LayerMask _overlapMask;

        [SerializeField]
        private LayerMask _raycastMask;

        [SerializeField]
        private Vector3 _raycastOffset;

        [SerializeField]
        [Range(0.0f, 360.0f)]
        private float _angle;

        [SerializeField]
        [HideInInspector]
        private float _halfAngle;

        [SerializeField]
        [Min(0.0f)]
        private float _radius;

        [SerializeField]
        [Min(1)]
        private int _maxEntries;

        [Header("Debug")]
        [SerializeField]
        private Color _mainDebugColor;

        [SerializeField]
        private Color _additionalDebugColor;

        private Collider[] _allocatedColliders;
        private List<IGameActor> _allocatedActors;

        public event Action<IReadOnlyList<IGameActor>> OnDetectActors;

        private void OnEnable()
        {
            _allocatedColliders = new Collider[_maxEntries];
            _allocatedActors = new List<IGameActor>(_maxEntries);
        }

        private void LateUpdate()
        {
            var position = transform.position;
            var raycastPosition = position + _raycastOffset;
            var forwardVector = transform.forward;

            var overlappedColliders =
                Physics.OverlapSphereNonAlloc(position, _radius, _allocatedColliders, _overlapMask);

            _allocatedActors.Clear();

            for (var i = 0; i < overlappedColliders; ++i)
            {
                var checkCollider = _allocatedColliders[i];
                var colliderPosition = checkCollider.transform.position;
                var directionToCollider = (colliderPosition - position).normalized;

                if (Vector3.Angle(forwardVector, directionToCollider) >= _halfAngle) continue;

                if (!Physics.Linecast(raycastPosition, colliderPosition + _raycastOffset, out var hit, _raycastMask)
                    || hit.colliderInstanceID != checkCollider.GetInstanceID()) continue;

                if (!checkCollider.TryGetComponent<IVisibilityAgent>(out var agent)
                    || !agent.IsVisible) continue;

                _allocatedActors.Add(agent.Actor);
            }

            if (_allocatedActors.Count > 0)
            {
                OnDetectActors?.Invoke(_allocatedActors);
            }
        }

#if UNITY_EDITOR
        private void OnValidate()
        {
            _halfAngle = _angle / 2;
        }

        private void OnDrawGizmos()
        {
            var detectorTransform = transform;
            var detectorPosition = detectorTransform.position;

            var leftEdgeDirection = Quaternion.Euler(0, -_halfAngle, 0) * detectorTransform.forward;
            var rightEdgeDirection = Quaternion.Euler(0, _halfAngle, 0) * detectorTransform.forward;

            Handles.color = _mainDebugColor;
            Handles.DrawSolidArc(detectorPosition, Vector3.up, leftEdgeDirection, _angle, _radius);

            Handles.color = _additionalDebugColor;

            Handles.DrawLine(detectorPosition, detectorPosition + leftEdgeDirection * _radius);
            Handles.DrawLine(detectorPosition, detectorPosition + rightEdgeDirection * _radius);
            Handles.DrawWireArc(detectorPosition, Vector3.up, leftEdgeDirection, _angle, _radius);
        }
#endif
    }
}