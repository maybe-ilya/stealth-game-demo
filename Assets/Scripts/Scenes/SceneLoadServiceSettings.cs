using MIG.API;
using UnityEngine;

namespace MIG.SceneLoading
{
    [CreateAssetMenu(menuName =
        AssetConsts.CREATE_ASSET_ROOT_MENU + "Scene Loading/" + nameof(SceneLoadServiceSettings))]
    public sealed class SceneLoadServiceSettings : ScriptableObject
    {
        [SerializeField] private int _emulatedDelayInSeconds;

        public int EmulatedDelayInSeconds => _emulatedDelayInSeconds;
    }
}