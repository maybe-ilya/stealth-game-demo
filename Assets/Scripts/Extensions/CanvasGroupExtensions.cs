using System.Runtime.CompilerServices;
using UnityEngine;

namespace MIG.Extensions
{
    public static class CanvasGroupExtensions
    {
        public static void Show(this CanvasGroup canvasGroup)
            => SetAlpha(canvasGroup, 1.0f);

        public static void Hide(this CanvasGroup canvasGroup)
            => SetAlpha(canvasGroup, 0.0f);

        public static void ReceiveInput(this CanvasGroup canvasGroup)
        {
            SetInteractable(canvasGroup, true);
            SetBlocksRaycasts(canvasGroup, true);
        }

        public static void IgnoreInput(this CanvasGroup canvasGroup)
        {
            SetInteractable(canvasGroup, false);
            SetBlocksRaycasts(canvasGroup, false);
        }

        public static void ShowAndReceiveInput(this CanvasGroup canvasGroup)
        {
            canvasGroup.ReceiveInput();
            canvasGroup.Show();
        }

        public static void HideAndIgnoreInput(this CanvasGroup canvasGroup)
        {
            canvasGroup.IgnoreInput();
            canvasGroup.Hide();
        }

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetAlpha(CanvasGroup canvasGroup, float newAlpha)
            => canvasGroup.alpha = newAlpha;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetInteractable(CanvasGroup canvasGroup, bool newInteractable)
            => canvasGroup.interactable = newInteractable;

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetBlocksRaycasts(CanvasGroup canvasGroup, bool newRaycastsBlock)
            => canvasGroup.blocksRaycasts = newRaycastsBlock;
    }
}