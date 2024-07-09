using MIG.API;
using MIG.App.States;
using MIG.LoadingScreen;
using MIG.Player.Impl;
using MIG.SceneLoading;
using MIG.UI.Windows;
using UnityEngine;

namespace MIG.Main
{
    public sealed class AppScopeDependencies : MonoBehaviour
    {
        [SerializeField] [CheckObject] private SceneLoadServiceSettings _sceneLoadServiceSettings;
        [SerializeField] [CheckObject] private MainMenuAppStateSettings _mainMenuAppStateSettings;
        [SerializeField] [CheckObject] private PlayGameAppStateSettings _playGameAppStateSettings;
        [SerializeField] [CheckObject] private MobileInputUIPanelFactorySettings _mobileInputUIPanelFactorySettings;
        [SerializeField] [CheckObject] private DefaultInputHandlerFactorySettings _defaultInputHandlerFactorySettings;
        [SerializeField] [CheckObject] private LoadingScreenFactorySettings _loadingScreenFactorySettings;

        [Header("UI")] [SerializeField] [CheckObject]
        private WindowHandlerSettings _windowHandlerSettings;

        [SerializeField] [CheckObject] private MainMenuWindowFactorySettings _mainMenuWindowFactorySettings;

        public SceneLoadServiceSettings LoadServiceSettings => _sceneLoadServiceSettings;

        public MainMenuAppStateSettings MenuAppStateSettings => _mainMenuAppStateSettings;

        public PlayGameAppStateSettings PlayGameAppStateSettings => _playGameAppStateSettings;

        public MobileInputUIPanelFactorySettings InputUIPanelFactorySettings => _mobileInputUIPanelFactorySettings;

        public DefaultInputHandlerFactorySettings DefaultInputHandlerFactorySettings =>
            _defaultInputHandlerFactorySettings;

        public WindowHandlerSettings WindowHandlerSettings => _windowHandlerSettings;

        public MainMenuWindowFactorySettings MainMenuWindowFactorySettings => _mainMenuWindowFactorySettings;

        public LoadingScreenFactorySettings LoadingScreenFactorySettings => _loadingScreenFactorySettings;
    }
}