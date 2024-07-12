using System;
using MIG.API;
using MIG.GameModes;
using MIG.Navigation;
using UnityEngine;

namespace MIG.Main
{
    public sealed class PlayGameScopeDependencies : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private DefaultPlayerStart _playerStart;

        [SerializeField]
        [CheckObject]
        private EscapeModeSettings _escapeModeSettings;

        [SerializeField]
        [CheckObject]
        private DefaultSpawner[] _banditSpawners = Array.Empty<DefaultSpawner>();

        [SerializeField]
        [CheckObject]
        private SimpleNavigationManager _navigationManager;

        [SerializeField]
        [CheckObject]
        private DefaultActorBoxTrigger _playerFinishTrigger;

        public DefaultPlayerStart PlayerStart => _playerStart;

        public EscapeModeSettings EscapeModeSettings => _escapeModeSettings;

        public DefaultSpawner[] BanditSpawners => _banditSpawners;

        public SimpleNavigationManager NavigationManager => _navigationManager;

        public DefaultActorBoxTrigger PlayerFinishTrigger => _playerFinishTrigger;
    }
}