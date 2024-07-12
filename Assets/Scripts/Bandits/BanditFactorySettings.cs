using System;
using MIG.API;
using UnityEngine;

namespace MIG.Bandits
{
    [CreateAssetMenu(menuName = AssetConsts.CREATE_ASSET_ROOT_MENU + "Enemies/" + nameof(BanditFactorySettings))]
    public sealed class BanditFactorySettings : ScriptableObject
    {
        [SerializeField]
        [CheckObject]
        private Bandit[] _banditPrefabs = Array.Empty<Bandit>();

        public Bandit[] BanditPrefabs => _banditPrefabs;
    }
}