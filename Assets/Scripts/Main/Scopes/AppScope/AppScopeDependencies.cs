using MIG.API;
using MIG.App.States;
using MIG.Bandits;
using MIG.Camera;
using MIG.LoadingScreen;
using MIG.Player.Impl;
using MIG.PlayerCharacter;
using MIG.SceneLoading;
using MIG.UI.Windows;
using UnityEngine;

namespace MIG.Main
{
    public sealed class AppScopeDependencies : MonoBehaviour
    {
        [SerializeField]
        [CheckObject]
        private SceneLoadServiceSettings _sceneLoadServiceSettings;

        [SerializeField]
        [CheckObject]
        private MainMenuAppStateSettings _mainMenuAppStateSettings;

        [SerializeField]
        [CheckObject]
        private PlayGameAppStateSettings _playGameAppStateSettings;

        [SerializeField]
        [CheckObject]
        private MobileInputUIPanelFactorySettings _mobileInputUIPanelFactorySettings;

        [SerializeField]
        [CheckObject]
        private DefaultInputHandlerFactorySettings _defaultInputHandlerFactorySettings;

        [SerializeField]
        [CheckObject]
        private LoadingScreenFactorySettings _loadingScreenFactorySettings;

        [Header("UI")]
        [SerializeField]
        [CheckObject]
        private WindowHandlerSettings _windowHandlerSettings;

        [SerializeField]
        [CheckObject]
        private MainMenuWindowFactorySettings _mainMenuWindowFactorySettings;

        [SerializeField]
        [CheckObject]
        private GameOverWindowFactorySettings _gameOverWindowFactorySettings;

        [SerializeField]
        [CheckObject]
        private PlayerHUDFactorySettings _playerHUDFactorySettings;

        [Header("Game Actors")]
        [SerializeField]
        [CheckObject]
        private CharacterFactorySettings _characterFactorySettings;

        [SerializeField]
        [CheckObject]
        private CameraActorFactorySettings _cameraActorFactorySettings;

        [SerializeField]
        [CheckObject]
        private BanditFactorySettings _banditFactorySettings;

        public SceneLoadServiceSettings LoadServiceSettings => _sceneLoadServiceSettings;

        public MainMenuAppStateSettings MenuAppStateSettings => _mainMenuAppStateSettings;

        public PlayGameAppStateSettings PlayGameAppStateSettings => _playGameAppStateSettings;

        public MobileInputUIPanelFactorySettings InputUIPanelFactorySettings => _mobileInputUIPanelFactorySettings;

        public DefaultInputHandlerFactorySettings DefaultInputHandlerFactorySettings =>
            _defaultInputHandlerFactorySettings;

        public WindowHandlerSettings WindowHandlerSettings => _windowHandlerSettings;

        public MainMenuWindowFactorySettings MainMenuWindowFactorySettings => _mainMenuWindowFactorySettings;

        public LoadingScreenFactorySettings LoadingScreenFactorySettings => _loadingScreenFactorySettings;

        public CharacterFactorySettings CharacterFactorySettings => _characterFactorySettings;

        public CameraActorFactorySettings CameraActorFactorySettings => _cameraActorFactorySettings;

        public BanditFactorySettings BanditFactorySettings => _banditFactorySettings;

        public GameOverWindowFactorySettings GameOverWindowFactorySettings => _gameOverWindowFactorySettings;

        public PlayerHUDFactorySettings PlayerHUDFactorySettings => _playerHUDFactorySettings;
    }
}