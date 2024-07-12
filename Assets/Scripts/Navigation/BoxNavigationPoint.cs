using MIG.API;
using MIG.Utils;
using UnityEngine;

namespace MIG.Navigation
{
    [RequireComponent(typeof(BoxCollider))]
    public sealed class BoxNavigationPoint : AbstractNavigationPoint
    {
        [SerializeField]
        [CheckObject]
        private BoxCollider _boxCollider;

        [Header("Debug")]
        [SerializeField]
        private Color _mainDebugColor;

        [SerializeField]
        private Color _addDebugColor;

#if UNITY_EDITOR
        private void Reset()
        {
            _boxCollider = GetComponent<BoxCollider>();
            _boxCollider.isTrigger = true;
        }

        private void OnDrawGizmos()
        {
            using var matrixScope = new GizmosMatrixScope(transform.localToWorldMatrix);
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