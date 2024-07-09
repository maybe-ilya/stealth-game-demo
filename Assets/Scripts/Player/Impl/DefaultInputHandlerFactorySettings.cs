using MIG.API;
using UnityEngine;
using UnityEngine.InputSystem.UI;

namespace MIG.Player.Impl
{
    [CreateAssetMenu(menuName =
        AssetConsts.CREATE_ASSET_ROOT_MENU + "Input/" + nameof(DefaultInputHandlerFactorySettings))]
    public sealed class DefaultInputHandlerFactorySettings : ScriptableObject
    {
        [SerializeField] [CheckObject] private InputSystemUIInputModule _inputModulePrefab;

        public InputSystemUIInputModule InputModulePrefab => _inputModulePrefab;
    }
}