using MIG.API;
using MIG.Extensions;
using UnityEngine;

namespace MIG.Player.Impl
{
    public sealed class MobileInputUIPanel : MonoBehaviour, IMobileInputUIPanel
    {
        [SerializeField]
        [CheckObject]
        private CanvasGroup _canvasGroup;

        public void Activate()
        {
            _canvasGroup.ShowAndReceiveInput();
        }

        public void Deactivate()
        {
            _canvasGroup.HideAndIgnoreInput();
        }
    }
}