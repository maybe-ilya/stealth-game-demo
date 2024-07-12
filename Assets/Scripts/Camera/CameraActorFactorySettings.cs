using MIG.API;
using UnityEngine;

namespace MIG.Camera
{
    [CreateAssetMenu(menuName = AssetConsts.CREATE_ASSET_ROOT_MENU + "Camera/" + nameof(CameraActorFactorySettings))]
    public sealed class CameraActorFactorySettings : ScriptableObject
    {
        [SerializeField]
        [CheckObject]
        private CameraActor _cameraActorPrefab;

        public CameraActor CameraActorPrefab => _cameraActorPrefab;
    }
}