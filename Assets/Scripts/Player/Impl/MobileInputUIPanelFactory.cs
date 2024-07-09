using UObject = UnityEngine.Object;

namespace MIG.Player.Impl
{
    public sealed class MobileInputUIPanelFactory : IMobileInputUIPanelFactory
    {
        private readonly MobileInputUIPanelFactorySettings _settings;

        public MobileInputUIPanelFactory(MobileInputUIPanelFactorySettings settings)
        {
            _settings = settings;
        }

        public IMobileInputUIPanel Create()
        {
            var result = UObject.Instantiate(_settings.PanelPrefab);
            UObject.DontDestroyOnLoad(result.gameObject);
            result.Deactivate();
            return result;
        }
    }
}