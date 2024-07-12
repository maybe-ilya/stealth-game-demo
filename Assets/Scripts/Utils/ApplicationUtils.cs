using UnityEngine;
using USystemInfo = UnityEngine.Device.SystemInfo;

namespace MIG.Utils
{
    public static class ApplicationUtils
    {
        public static bool IsMobile =>
            Application.isMobilePlatform ||
            USystemInfo.deviceType == DeviceType.Handheld; //  this was added to support editor's simulator mode

        public static bool IsDesktop =>
            !Application.isMobilePlatform && !Application.isConsolePlatform;

        public static bool IsEditor =>
            Application.isEditor;

        public static bool IsDevBuild =>
            Debug.isDebugBuild;
    }
}