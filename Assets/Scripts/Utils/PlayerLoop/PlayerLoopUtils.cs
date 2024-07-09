using UnityEngine.LowLevel;

namespace MIG.Utils
{
    public static class PlayerLoopUtils
    {
        public static void ResetPlayerLoopSystems()
        {
            PlayerLoop.SetPlayerLoop(PlayerLoop.GetDefaultPlayerLoop());
        }
    }
}