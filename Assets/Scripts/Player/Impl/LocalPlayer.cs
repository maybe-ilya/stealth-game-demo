using MIG.API;

namespace MIG.Player.Impl
{
    public sealed class LocalPlayer : ILocalPlayer
    {
        private readonly IActivatablePlayerInputHandler _playerInputHandler;

        public LocalPlayer(IActivatablePlayerInputHandler playerInputHandler)
        {
            _playerInputHandler = playerInputHandler;
        }

        public IPlayerInputHandler PlayerInputHandler => _playerInputHandler;

        public void ActivateInput()
            => _playerInputHandler.Activate();

        public void DeactivateInput()
            => _playerInputHandler.Deactivate();
    }
}