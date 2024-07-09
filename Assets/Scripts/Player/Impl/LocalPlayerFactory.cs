namespace MIG.Player.Impl
{
    public sealed class LocalPlayerFactory : ILocalPlayerFactory
    {
        private readonly IMultiModePlayerInputHandlerFactory _playerInputHandlerFactory;

        public LocalPlayerFactory(IMultiModePlayerInputHandlerFactory playerInputHandlerFactory)
        {
            _playerInputHandlerFactory = playerInputHandlerFactory;
        }

        public ILocalPlayer Create()
            => new LocalPlayer(_playerInputHandlerFactory.Create());
    }
}