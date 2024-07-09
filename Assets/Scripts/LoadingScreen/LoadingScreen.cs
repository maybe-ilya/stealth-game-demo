using MIG.API;
using MIG.Extensions;
using UnityEngine;

namespace MIG.LoadingScreen
{
    [RequireComponent(typeof(CanvasGroup))]
    public sealed class LoadingScreen : MonoBehaviour, ILoadingScreen
    {
        [SerializeField] [CheckObject] private CanvasGroup _canvasGroup;

        public void Show()
            => _canvasGroup.Show();

        public void Hide()
            => _canvasGroup.Hide();

#if UNITY_EDITOR
        private void Reset()
        {
            _canvasGroup = GetComponent<CanvasGroup>();
        }
#endif
    }
}