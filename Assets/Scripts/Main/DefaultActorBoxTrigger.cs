using System;
using MIG.API;
using MIG.Utils;
using UnityEngine;

namespace MIG.Main
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class DefaultActorBoxTrigger : MonoBehaviour, IGameActorTrigger
    {
        [SerializeField]
        [CheckObject]
        private BoxCollider _boxCollider;

        [Header("Debug")]
        [SerializeField]
        private Color _mainDebugColor;

        [SerializeField]
        private Color _addDebugColor;

        public event Action<IGameActor> OnActorEnter;
        public event Action<IGameActor> OnActorExit;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<IGameActor>(out var actor)) return;
            OnActorEnter?.Invoke(actor);
        }

        private void OnTriggerExit(Collider other)
        {
            if (!other.TryGetComponent<IGameActor>(out var actor)) return;
            OnActorExit?.Invoke(actor);
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _boxCollider.isTrigger = true;
        }

        private void OnDrawGizmos()
        {
            using var _ = new GizmosMatrixScope(transform.localToWorldMatrix);

            using (new GizmosColorScope(_mainDebugColor))
            {
                Gizmos.DrawCube(_boxCollider.center, _boxCollider.size);
            }

            using (new GizmosColorScope(_addDebugColor))
            {
                Gizmos.DrawWireCube(_boxCollider.center, _boxCollider.size);
            }
        }
#endif
    }
}