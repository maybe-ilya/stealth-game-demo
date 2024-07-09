using UObject = UnityEngine.Object;

namespace MIG.Player.Impl
{
    public sealed class DefaultInputHandlerFactory : IMultiModePlayerInputHandlerFactory
    {
        private readonly DefaultInputHandlerFactorySettings _settings;

        public DefaultInputHandlerFactory(DefaultInputHandlerFactorySettings settings)
        {
            _settings = settings;
        }

        public IMultiModePlayerInputHandler Create()
        {
            var inputModule = UObject.Instantiate(_settings.InputModulePrefab);
            UObject.DontDestroyOnLoad(inputModule.gameObject);
            return new DefaultInputHandler(inputModule);
        }
    }
}