using System;
using System.Collections.Generic;
using MIG.API;
using UnityEngine;
using UnityEngine.AI;

namespace MIG.Bandits
{
    [RequireComponent(typeof(BanditVisibilityDetector))]
    [RequireComponent(typeof(NavMeshAgent))]
    [RequireComponent(typeof(BanditAnimator))]
    public class Bandit : MonoBehaviour,
        IBandit,
        INavigationAgent
    {
        [SerializeField]
        [CheckObject]
        private BanditVisibilityDetector _visibilityDetector;

        [SerializeField]
        [CheckObject]
        private NavMeshAgent _navMeshAgent;

        [SerializeField]
        [CheckObject]
        private BanditAnimator _banditAnimator;

        private IVisibilityNotifyInvoker _notifyInvoker;
        private INavigationManager _navigationManager;
        private INavigationPoint _currentTarget;

        public int Id { get; set; }
        public Transform Transform => transform;
        public IGameActor Actor => this;

        public void SetTarget(INavigationPoint newTarget)
        {
            _currentTarget = newTarget;
            StartNavMeshAgent();
            _navMeshAgent.SetDestination(_currentTarget.Position);
        }

        public void OnReachPoint(INavigationPoint reachedPoint)
        {
            if (_currentTarget is not null && _currentTarget.Id != reachedPoint.Id) return;
            StopNavMeshAgent();
            RequestNewTarget();
        }

        public void SetVisibilityNotifyInvoker(IVisibilityNotifyInvoker notifyInvoker)
            => _notifyInvoker = notifyInvoker;

        public void StartPatrol()
        {
            RequestNewTarget();
        }

        public void StopPatrol()
        {
            StopNavMeshAgent();
            CancelTarget();
        }

        public void ShootTo(IGameActor gameActor)
        {
            StopPatrol();
            transform.LookAt(gameActor.Transform, Vector3.up);
            _banditAnimator.PlayShootAnim();
        }

        public void SetNavigationManager(INavigationManager navigationManager)
            => _navigationManager = navigationManager;

        private void OnEnable()
        {
            _visibilityDetector.OnDetectActors += OnDetectActor;
        }

        private void OnDisable()
        {
            _visibilityDetector.OnDetectActors -= OnDetectActor;
        }

        private void Update()
        {
            _banditAnimator.SetSpeed(_navMeshAgent.velocity.magnitude / _navMeshAgent.speed);
        }

        private void OnDetectActor(IReadOnlyList<IGameActor> detectedActors)
            => _notifyInvoker?.NofifyActorObservation(this, detectedActors);

        private void RequestNewTarget()
            => _navigationManager.RequestNewTarget(this, _currentTarget);

        private void CancelTarget()
            => _navigationManager.CancelTarget(this);

        private void StartNavMeshAgent()
            => _navMeshAgent.isStopped = false;

        private void StopNavMeshAgent()
        {
            _navMeshAgent.isStopped = true;
            _navMeshAgent.ResetPath();
            _navMeshAgent.velocity = Vector3.zero;
        }

#if UNITY_EDITOR
        private void Reset()
        {
            _visibilityDetector = GetComponent<BanditVisibilityDetector>();
            _navMeshAgent = GetComponent<NavMeshAgent>();
            _banditAnimator = GetComponent<BanditAnimator>();
        }
#endif
    }
}