namespace MIG.Player.Impl
{
    public sealed class LocalPlayerFactory : ILocalPlayerFactory
    {
        private readonly IActivatablePlayerInputHandlerFactory _playerInputHandlerFactory;

        public LocalPlayerFactory(IActivatablePlayerInputHandlerFactory playerInputHandlerFactory)
        {
            _playerInputHandlerFactory = playerInputHandlerFactory;
        }

        public ILocalPlayer Create()
            => new LocalPlayer(_playerInputHandlerFactory.Create());
    }
}