using System;
using UnityEngine;

namespace MIG.Camera
{
    public class CameraFollowMovement : MonoBehaviour
    {
        [Flags]
        private enum FollowType
        {
            None = 0,
            Position = 1,
            Rotation = 2,
        }

        [SerializeField]
        private FollowType _followType;

        private Transform _target;

        public void SetTarget(Transform newTarget)
        {
            _target = newTarget;
        }

        public void ClearTarget()
        {
            _target = null;
        }

        private bool CanFollowTarget()
        {
            return _target is not null && _followType != FollowType.None;
        }

        private void ProcessFollow()
        {
            if (!CanFollowTarget()) return;

            if (_followType.HasFlag(FollowType.Position))
            {
                ProcessPositionFollow();
            }

            if (_followType.HasFlag(FollowType.Rotation))
            {
                ProcessRotationFollow();
            }
        }

        private void ProcessPositionFollow()
            => transform.position = _target.position;

        private void ProcessRotationFollow()
            => transform.rotation = _target.rotation;

        private void LateUpdate()
            => ProcessFollow();
    }
}