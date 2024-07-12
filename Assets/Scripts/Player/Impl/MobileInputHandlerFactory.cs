namespace MIG.Player
{
    public sealed class MobileInputHandlerFactory : IActivatablePlayerInputHandlerFactory
    {
        private readonly IActivatablePlayerInputHandlerFactory _baseInputHandlerFactory;
        private readonly IMobileInputUIPanelFactory _mobileInputUIPanelFactory;

        public MobileInputHandlerFactory(
            IActivatablePlayerInputHandlerFactory baseInputHandlerFactory,
            IMobileInputUIPanelFactory mobileInputUIPanelFactory
        )
        {
            _baseInputHandlerFactory = baseInputHandlerFactory;
            _mobileInputUIPanelFactory = mobileInputUIPanelFactory;
        }

        public IActivatablePlayerInputHandler Create()
            => new MobileInputHandler(_baseInputHandlerFactory.Create(), _mobileInputUIPanelFactory.Create());
    }
}