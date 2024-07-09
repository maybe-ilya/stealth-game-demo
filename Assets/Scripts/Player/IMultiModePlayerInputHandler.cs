using MIG.API;

namespace MIG.Player
{
    public interface IMultiModePlayerInputHandler : IPlayerInputHandler
    {
        void SetGameInputMode();
        void SetUIInputMode();
    }
}