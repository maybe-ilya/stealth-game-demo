using MIG.API;

namespace MIG.Player
{
    public interface ILocalPlayer
    {
        void ActivateInput();
        void DeactivateInput();
        IPlayerInputHandler PlayerInputHandler { get; }
    }
}