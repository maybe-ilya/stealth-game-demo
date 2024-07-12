using MIG.API;
using UnityEngine;

namespace MIG.Navigation
{
    public abstract class AbstractNavigationPoint : MonoBehaviour, INavigationPoint
    {
        [SerializeField]
        [Min(0)]
        private int _id;

        public int Id => _id;

        public Vector3 Position => transform.position;

        private void OnTriggerEnter(Collider other)
        {
            if (!other.TryGetComponent<INavigationAgent>(out var agent)) return;
            agent.OnReachPoint(this);
        }
    }
}