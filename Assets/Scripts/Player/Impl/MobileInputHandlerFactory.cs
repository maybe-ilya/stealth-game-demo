namespace MIG.Player
{
    public sealed class MobileInputHandlerFactory : IMultiModePlayerInputHandlerFactory
    {
        private readonly IMultiModePlayerInputHandlerFactory _baseInputHandlerFactory;
        private readonly IMobileInputUIPanelFactory _mobileInputUIPanelFactory;

        public MobileInputHandlerFactory(
            IMultiModePlayerInputHandlerFactory baseInputHandlerFactory,
            IMobileInputUIPanelFactory mobileInputUIPanelFactory
        )
        {
            _baseInputHandlerFactory = baseInputHandlerFactory;
            _mobileInputUIPanelFactory = mobileInputUIPanelFactory;
        }

        public IMultiModePlayerInputHandler Create()
            => new MobileInputHandler(_baseInputHandlerFactory.Create(), _mobileInputUIPanelFactory.Create());
    }
}