using MIG.API;
using UnityEngine;

namespace MIG.App.States
{
    [CreateAssetMenu(menuName = AssetConsts.CREATE_ASSET_ROOT_MENU + "App States/" + nameof(PlayGameAppStateSettings))]
    public sealed class PlayGameAppStateSettings : ScriptableObject
    {
        [SerializeField]
        [SceneIndex]
        private int _playGameSceneIndex;

        public int PlayGameSceneIndex => _playGameSceneIndex;
    }
}