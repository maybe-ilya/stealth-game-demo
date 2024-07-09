using MIG.API;

namespace MIG.Player
{
    public interface ILocalPlayer
    {
        void SetGameplayInputMode();
        void SetUIInputMode();
        IPlayerInputHandler PlayerInputHandler { get; }
    }
}