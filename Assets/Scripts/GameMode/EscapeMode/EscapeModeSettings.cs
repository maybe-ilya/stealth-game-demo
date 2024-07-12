using MIG.API;
using UnityEngine;

namespace MIG.GameModes
{
    [CreateAssetMenu(menuName = AssetConsts.CREATE_ASSET_ROOT_MENU + "Game Modes/" + nameof(EscapeModeSettings))]
    public sealed class EscapeModeSettings : ScriptableObject
    {
        [SerializeField]
        private float _finishTimeInSeconds;

        [SerializeField]
        private int _enemiesCount;

        public float FinishTimeInSeconds => _finishTimeInSeconds;

        public int EnemiesCount => _enemiesCount;
    }
}