using MIG.API;
using UnityEngine.SceneManagement;

namespace MIG.SceneLoading
{
    public sealed class SceneDataService : ISceneDataService
    {
        public int CurrentSceneIndex
            => CurrentScene.buildIndex;

        public string CurrentSceneName
            => CurrentScene.name;

        private static Scene CurrentScene
            => SceneManager.GetActiveScene();
    }
}