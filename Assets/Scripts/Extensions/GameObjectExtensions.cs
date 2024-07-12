using System.Runtime.CompilerServices;
using UnityEngine;

namespace MIG.Extensions
{
    public static class GameObjectExtensions
    {
        private const string UNTAGGED_TAG = "Untagged";
        private const string MAIN_CAMERA_TAG = "MainCamera";

        public static void Activate(this GameObject gameObject)
            => SetActive(gameObject, true);

        public static void Deactivate(this GameObject gameObject)
            => SetActive(gameObject, false);

        public static void Activate(this Behaviour behaviour)
            => SetActive(behaviour.gameObject, true);

        public static void Deactivate(this Behaviour behaviour)
            => SetActive(behaviour.gameObject, false);

        public static void MakeUntagged(this GameObject gameObject)
            => SetTag(gameObject, UNTAGGED_TAG);

        public static void MakeMainCamera(this GameObject gameObject)
            => SetTag(gameObject, MAIN_CAMERA_TAG);

        public static void MakeUntagged(this Behaviour behaviour)
            => SetTag(behaviour.gameObject, UNTAGGED_TAG);

        public static void MakeMainCamera(this Behaviour behaviour)
            => SetTag(behaviour.gameObject, MAIN_CAMERA_TAG);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetActive(GameObject gameObject, bool newActive)
            => gameObject.SetActive(newActive);

        [MethodImpl(MethodImplOptions.AggressiveInlining)]
        private static void SetTag(GameObject gameObject, string newTag)
            => gameObject.tag = newTag;
    }
}