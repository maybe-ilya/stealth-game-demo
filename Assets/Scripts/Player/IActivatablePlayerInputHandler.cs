using MIG.API;

namespace MIG.Player
{
    public interface IActivatablePlayerInputHandler : IPlayerInputHandler
    {
        void Activate();
        void Deactivate();
    }
}