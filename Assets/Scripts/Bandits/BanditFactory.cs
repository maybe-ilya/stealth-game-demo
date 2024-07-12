using System;
using MIG.API;
using MIG.Extensions;
using MIG.GameActors;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace MIG.Bandits
{
    public sealed class BanditFactory : IGameActorFactory
    {
        private readonly BanditFactorySettings _settings;
        private readonly INavigationService _navigationService;

        public BanditFactory(BanditFactorySettings settings, INavigationService navigationService)
        {
            _settings = settings;
            _navigationService = navigationService;
        }

        public Type ActorType => typeof(IBandit);

        public IGameActor Create(int id)
            => CreateInternal(id, Vector3.zero, Quaternion.identity);

        public IGameActor Create(int id, Vector3 position)
            => CreateInternal(id, position, Quaternion.identity);

        public IGameActor Create(int id, Vector3 position, Quaternion rotation)
            => CreateInternal(id, position, rotation);

        private IBandit CreateInternal(int id, Vector3 position, Quaternion rotation)
        {
            var banditPrefab = _settings.BanditPrefabs.PickRandomElement();
            var result = UObject.Instantiate(banditPrefab, position, rotation);
            result.Id = id;
            result.SetNavigationManager(_navigationService.NavigationManager);
            return result;
        }
    }
}