using System;
using System.Collections.Generic;
using UnityEngine.LowLevel;

namespace MIG.Utils
{
    public sealed class PlayerLoopSystemInjector
    {
        private readonly Dictionary<Type, List<PlayerLoopSystem>> _systemsToInject = new();

        public PlayerLoopSystemInjector AddSystem<TTargetSystem>(PlayerLoopSystem newSystem)
            where TTargetSystem : struct
        {
            var targetType = typeof(TTargetSystem);

            if (!_systemsToInject.TryGetValue(targetType, out var systemList))
            {
                _systemsToInject[targetType] = systemList = new List<PlayerLoopSystem>();
            }

            systemList.Add(newSystem);

            return this;
        }


        public PlayerLoopSystemInjector AddSystem<TTargetSystem, TInjectSystem>(
            PlayerLoopSystem.UpdateFunction updateFunction)
            where TTargetSystem : struct
            where TInjectSystem : struct
        {
            return AddSystem<TTargetSystem>(new PlayerLoopSystem()
            {
                updateDelegate = updateFunction,
                type = typeof(TInjectSystem),
                subSystemList = null
            });
        }

        public void Inject()
        {
            var currentPlayerLoop = PlayerLoop.GetCurrentPlayerLoop();

            var newPlayerLoop = new PlayerLoopSystem()
            {
                loopConditionFunction = currentPlayerLoop.loopConditionFunction,
                type = currentPlayerLoop.type,
                updateDelegate = currentPlayerLoop.updateDelegate,
                updateFunction = currentPlayerLoop.updateFunction
            };

            List<PlayerLoopSystem> newSubSystemList = new();

            foreach (var subSystem in currentPlayerLoop.subSystemList)
            {
                newSubSystemList.Add(subSystem);

                if (_systemsToInject.TryGetValue(subSystem.type, out var systemsToInjectForType))
                {
                    newSubSystemList.AddRange(systemsToInjectForType);
                }
            }

            newPlayerLoop.subSystemList = newSubSystemList.ToArray();

            PlayerLoop.SetPlayerLoop(newPlayerLoop);
        }
    }
}