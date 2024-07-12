namespace MIG.API
{
    public interface IPlayerCharacter : IGameActor
    {
        void Win();
        void Lose();
    }
}