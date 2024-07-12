using MIG.API;
using UObject = UnityEngine.Object;

namespace MIG.UI.Windows
{
    public sealed class PlayerHUDFactory : AbstractWindowFactory<IPlayerHUD>
    {
        private readonly PlayerHUDFactorySettings _settings;

        public PlayerHUDFactory(PlayerHUDFactorySettings settings)
        {
            _settings = settings;
        }

        protected override IPlayerHUD CreateInternal()
        {
            var result = UObject.Instantiate(_settings.PlayerHUDPrefab);
            return result;
        }
    }
}