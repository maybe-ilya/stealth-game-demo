using System;
using MIG.API;
using MIG.GameActors;
using UnityEngine;
using UObject = UnityEngine.Object;

namespace MIG.PlayerCharacter
{
    public sealed class CharacterFactory : IGameActorFactory
    {
        private readonly CharacterFactorySettings _settings;
        private readonly IPlayerService _playerService;

        public CharacterFactory(
            CharacterFactorySettings settings,
            IPlayerService playerService
        )
        {
            _settings = settings;
            _playerService = playerService;
        }

        public Type ActorType => typeof(IPlayerCharacter);

        public IGameActor Create(int id)
            => CreateInternal(id, Vector3.zero, Quaternion.identity);

        public IGameActor Create(int id, Vector3 position)
            => CreateInternal(id, position, Quaternion.identity);

        public IGameActor Create(int id, Vector3 position, Quaternion rotation)
            => CreateInternal(id, position, rotation);

        private IPlayerCharacter CreateInternal(int id, Vector3 position, Quaternion rotation)
        {
            var character = UObject.Instantiate(_settings.CharacterPrefab, position, rotation);
            character.Id = id;
            character.SetupInput(_playerService.PlayerInputHandler);
            return character;
        }
    }
}