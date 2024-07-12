using System;
using System.Collections.Generic;
using System.Linq;
using MIG.API;
using MIG.Extensions;
using UnityEngine;

namespace MIG.Navigation
{
    public sealed class SimpleNavigationManager :
        MonoBehaviour,
        INavigationManager
    {
        [SerializeField]
        [CheckObject]
        private AbstractNavigationPoint[] _navPoints = Array.Empty<AbstractNavigationPoint>();

        private Dictionary<int, INavigationPoint> _navigationPointsById = new();
        private Dictionary<int, int> _actorIdTargetIds = new();
        private Dictionary<int, int> _actorIdVisitedIds = new();
        private Dictionary<int, bool> _pointFreeFlags = new();
        private Queue<INavigationAgent> _waitQueue = new();

        private const int INVALID_POINT_ID = -1;

        public void RequestNewTarget(INavigationAgent agent, INavigationPoint lastTarget)
        {
            if (lastTarget is not null)
            {
                FreePoint(agent.Actor.Id, lastTarget.Id);
            }

            PutAgentInWaitQueue(agent);
            TryToSetNextTarget();
        }

        public void CancelTarget(INavigationAgent agent)
        {
            var agentId = agent.Actor.Id;
            if (!_actorIdTargetIds.Remove(agentId, out var pointId)) return;
            FreePoint(agentId, pointId);
        }

        private void Start()
        {
            InitPoints();
        }

        private void InitPoints()
        {
            foreach (var point in _navPoints)
            {
                var pointId = point.Id;
                if (!_navigationPointsById.TryAdd(pointId, point) || !_pointFreeFlags.TryAdd(pointId, true))
                {
                    throw new ArgumentException(
                        $"Duplicate {nameof(INavigationPoint)}.{nameof(INavigationPoint.Id)} = {pointId}");
                }
            }
        }

        private void FreePoint(int agentId, int pointId)
        {
            _actorIdTargetIds[agentId] = INVALID_POINT_ID;
            _actorIdVisitedIds[agentId] = pointId;
            _pointFreeFlags[pointId] = true;
        }

        private void OccupyPoint(int agentId, int pointId)
        {
            _actorIdTargetIds[agentId] = pointId;
            _pointFreeFlags[pointId] = false;
        }

        private void SetTarget(INavigationAgent agent, int pointId)
            => agent.SetTarget(_navigationPointsById[pointId]);

        private void PutAgentInWaitQueue(INavigationAgent agent)
            => _waitQueue.Enqueue(agent);

        private void TryToSetNextTarget()
        {
            if (_waitQueue.Count == 0 || _pointFreeFlags.Values.All(value => !value)) return;

            var nextAgent = _waitQueue.Peek();
            var agentId = nextAgent.Actor.Id;
            var excludePointId = _actorIdVisitedIds.TryGetValue(agentId, out var pointId) ? pointId : INVALID_POINT_ID;

            var possibleTargetPointIds = _pointFreeFlags
                .Where(pair => pair.Value && pair.Key != excludePointId)
                .Select(pair => pair.Key)
                .ToArray();

            if (possibleTargetPointIds.Length == 0) return;

            var targetPointId = possibleTargetPointIds.PickRandomElement();
            OccupyPoint(agentId, targetPointId);
            SetTarget(_waitQueue.Dequeue(), targetPointId);
        }
    }
}