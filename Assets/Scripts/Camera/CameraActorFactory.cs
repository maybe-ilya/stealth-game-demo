using System;
using MIG.API;
using MIG.GameActors;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace MIG.Camera
{
    public sealed class CameraActorFactory : IGameActorFactory
    {
        private readonly CameraActorFactorySettings _settings;

        public CameraActorFactory(CameraActorFactorySettings settings)
        {
            _settings = settings;
        }

        public Type ActorType => typeof(ICameraActor);

        public IGameActor Create(int id)
            => CreateInternal(id, Vector3.zero, Quaternion.identity);

        public IGameActor Create(int id, Vector3 position)
            => CreateInternal(id, position, Quaternion.identity);

        public IGameActor Create(int id, Vector3 position, Quaternion rotation)
            => CreateInternal(id, position, rotation);

        private ICameraActor CreateInternal(int id, Vector3 position, Quaternion rotation)
        {
            var result = UObject.Instantiate(_settings.CameraActorPrefab, position, rotation);
            result.Id = id;
            return result;
        }
    }
}