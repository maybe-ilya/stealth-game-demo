using MIG.API;
using UnityEngine;

namespace MIG.Camera
{
    [RequireComponent(typeof(CameraFollowMovement))]
    public sealed class CameraActor : MonoBehaviour, ICameraActor
    {
        [SerializeField]
        [CheckObject]
        private CameraFollowMovement _cameraFollowMovement;

        public int Id { get; set; }

        public Transform Transform => transform;

        public void StartWatchingTo(IGameActor gameActor)
            => _cameraFollowMovement.SetTarget(gameActor.Transform);

        public void StopWatching()
            => _cameraFollowMovement.ClearTarget();

#if UNITY_EDITOR
        private void Reset()
        {
            _cameraFollowMovement = GetComponent<CameraFollowMovement>();
        }
#endif
    }
}