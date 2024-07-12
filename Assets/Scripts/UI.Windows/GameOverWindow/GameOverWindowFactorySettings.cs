using MIG.API;
using UnityEngine;

namespace MIG.UI.Windows
{
    [CreateAssetMenu(menuName =
        AssetConsts.CREATE_ASSET_ROOT_MENU + "UI/Windows/" + nameof(GameOverWindowFactorySettings))]
    public sealed class GameOverWindowFactorySettings : ScriptableObject
    {
        [SerializeField]
        [CheckObject]
        private GameOverWindow _gameOverWindowPrefab;

        [SerializeField]
        private string _timeMessageFormat;

        public GameOverWindow GameOverWindowPrefab => _gameOverWindowPrefab;

        public string TimeMessageFormat => _timeMessageFormat;
    }
}