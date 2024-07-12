using MIG.API;
using MIG.Utils;
using UnityEngine;

namespace MIG.Navigation
{
    [RequireComponent(typeof(SphereCollider))]
    public sealed class SphereNavigationPoint : AbstractNavigationPoint
    {
        [SerializeField]
        [CheckObject]
        private SphereCollider _sphereCollider;

        [Header("Debug")]
        [SerializeField]
        private Color _mainDebugColor;

        [SerializeField]
        private Color _addDebugColor;

#if UNITY_EDITOR
        private void Reset()
        {
            _sphereCollider = GetComponent<SphereCollider>();
            _sphereCollider.isTrigger = true;
        }

        private void OnDrawGizmos()
        {
            using var matrixScope = new GizmosMatrixScope(transform.localToWorldMatrix);
            using (new GizmosColorScope(_mainDebugColor))
            {
                Gizmos.DrawSphere(_sphereCollider.center, _sphereCollider.radius);
            }

            using (new GizmosColorScope(_addDebugColor))
            {
                Gizmos.DrawWireSphere(_sphereCollider.center, _sphereCollider.radius);
            }
        }
#endif
    }
}