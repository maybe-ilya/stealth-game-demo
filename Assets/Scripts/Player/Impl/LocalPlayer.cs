using MIG.API;

namespace MIG.Player.Impl
{
    public sealed class LocalPlayer : ILocalPlayer
    {
        private readonly IMultiModePlayerInputHandler _playerInputHandler;

        public LocalPlayer(IMultiModePlayerInputHandler playerInputHandler)
        {
            _playerInputHandler = playerInputHandler;
        }

        public IPlayerInputHandler PlayerInputHandler => _playerInputHandler;

        public void SetGameplayInputMode()
            => _playerInputHandler.SetGameInputMode();

        public void SetUIInputMode()
            => _playerInputHandler.SetUIInputMode();
    }
}