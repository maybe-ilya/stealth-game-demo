using Cysharp.Threading.Tasks;

namespace MIG.API
{
    public interface ISceneLoadService : IService
    {
        UniTask LoadSceneAsync(string sceneName);
        UniTask LoadSceneAsync(int sceneBuildIndex);
        void LoadScene(string sceneName);
        void LoadScene(int sceneBuildIndex);
    }
}