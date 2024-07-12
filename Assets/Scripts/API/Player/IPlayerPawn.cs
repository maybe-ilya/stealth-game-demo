namespace MIG.API
{
    public interface IPlayerPawn
    {
        void SetupInput(IPlayerInputHandler inputHandler);
        void ClearInputs();
    }
}