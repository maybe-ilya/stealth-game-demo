using UnityEngine;

namespace MIG.Utils
{
    public static class ApplicationUtils
    {
        public static bool IsMobile =>
            Application.isMobilePlatform;

        public static bool IsDesktop =>
            !Application.isMobilePlatform && !Application.isConsolePlatform;

        public static bool IsEditor =>
            Application.isEditor;

        public static bool IsDevBuild =>
            Debug.isDebugBuild;
    }
}