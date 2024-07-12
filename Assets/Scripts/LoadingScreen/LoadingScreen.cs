using MIG.API;
using MIG.Extensions;
using UnityEngine;

namespace MIG.LoadingScreen
{
    public sealed class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField]
        [CheckObject]
        private CanvasGroup _canvasGroup;

        [SerializeField]
        [CheckObject]
        private Camera _camera;

        public void Show()
        {
            _canvasGroup.Show();
            _camera.MakeMainCamera();
            _camera.Activate();
        }

        public void Hide()
        {
            _camera.Deactivate();
            _camera.MakeUntagged();
            _canvasGroup.Hide();
        }
    }
}