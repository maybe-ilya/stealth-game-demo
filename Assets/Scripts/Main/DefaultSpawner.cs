using MIG.API;
using MIG.Utils;
using UnityEngine;

namespace MIG.Main
{
    public sealed class DefaultSpawner : MonoBehaviour, ISpawner
    {
        [SerializeField]
        private Vector3 _meshGizmosOffset;

        [SerializeField]
        private Color _meshGizmoColor;

        public Transform Transform => transform;

        private void OnDrawGizmos()
        {
            using var _1 = new GizmosMatrixScope(transform.localToWorldMatrix);

            var mesh = PrimitiveUtils.GetPrimitiveMesh(PrimitiveType.Capsule);

            using var _2 = new GizmosColorScope(_meshGizmoColor);
            Gizmos.DrawMesh(mesh, _meshGizmosOffset);
        }
    }
}