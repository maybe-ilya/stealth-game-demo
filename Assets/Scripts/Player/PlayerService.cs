using MIG.API;

namespace MIG.Player
{
    public sealed class PlayerService : IPlayerService
    {
        private readonly ILocalPlayerFactory _localPlayerFactory;
        private ILocalPlayer _localPlayer;

        public IPlayerInputHandler PlayerInputHandler
            => _localPlayer.PlayerInputHandler;

        public PlayerService(ILocalPlayerFactory localPlayerFactory)
        {
            _localPlayerFactory = localPlayerFactory;
        }

        public void Init()
            => _localPlayer = _localPlayerFactory.Create();

        public void ActivateInput()
            => _localPlayer.ActivateInput();

        public void DeactivateInput()
            => _localPlayer.DeactivateInput();
    }
}