using System;
using MIG.API;

namespace MIG.GameModes
{
    public sealed class GameModeService : IGameModeService
    {
        private readonly IGameModeFactory _gameModeFactory;
        private IGameMode _gameMode;

        public event Action<GameModeResultData> OnFinish;

        public GameModeService(IGameModeFactory gameModeFactory)
        {
            _gameModeFactory = gameModeFactory;
        }

        public void Setup()
        {
            _gameMode = _gameModeFactory.Create();
        }

        public void Start()
        {
            _gameMode.OnFinish += OnGameModeFinish;
            _gameMode.Start();
        }

        public void Stop()
        {
            _gameMode.Stop();
        }

        private void OnGameModeFinish(GameModeResultData resultData)
        {
            Stop();
            OnFinish?.Invoke(resultData);
        }
    }
}