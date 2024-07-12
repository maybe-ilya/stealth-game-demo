using MIG.API;
using UnityEngine;

namespace MIG.PlayerCharacter
{
    [CreateAssetMenu(menuName = AssetConsts.CREATE_ASSET_ROOT_MENU + "Player/" + nameof(CharacterFactorySettings))]
    public sealed class CharacterFactorySettings : ScriptableObject
    {
        [SerializeField]
        [CheckObject]
        private Character _characterPrefab;

        public Character CharacterPrefab => _characterPrefab;
    }
}