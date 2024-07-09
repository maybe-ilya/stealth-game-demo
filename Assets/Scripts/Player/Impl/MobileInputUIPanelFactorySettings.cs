using MIG.API;
using UnityEngine;

namespace MIG.Player.Impl
{
    [CreateAssetMenu(menuName =
        AssetConsts.CREATE_ASSET_ROOT_MENU + "Input/" + nameof(MobileInputUIPanelFactorySettings))]
    public sealed class MobileInputUIPanelFactorySettings : ScriptableObject
    {
        [SerializeField] [CheckObject] private MobileInputUIPanel _panelPrefab;

        public MobileInputUIPanel PanelPrefab => _panelPrefab;
    }
}