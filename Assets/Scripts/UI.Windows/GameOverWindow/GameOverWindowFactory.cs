using MIG.API;
using UObject = UnityEngine.Object;

namespace MIG.UI.Windows
{
    public class GameOverWindowFactory : AbstractWindowFactory<IGameOverWindow>
    {
        private readonly GameOverWindowFactorySettings _settings;

        public GameOverWindowFactory(GameOverWindowFactorySettings settings)
        {
            _settings = settings;
        }

        protected override IGameOverWindow CreateInternal()
        {
            var result = UObject.Instantiate(_settings.GameOverWindowPrefab);
            result.Setup(_settings.TimeMessageFormat);
            return result;
        }
    }
}