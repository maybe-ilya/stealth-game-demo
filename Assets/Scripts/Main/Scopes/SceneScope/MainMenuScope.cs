using MIG.API;

namespace MIG.Main
{
    public sealed class MainMenuScope : ISceneScope
    {
        private readonly ILogService _logger;

        public MainMenuScope(ILogService logger)
        {
            _logger = logger;
        }

        public void Activate()
        {
            _logger.Info("Main menu loaded");
        }

        public void Deactivate()
        {
        }
    }
}