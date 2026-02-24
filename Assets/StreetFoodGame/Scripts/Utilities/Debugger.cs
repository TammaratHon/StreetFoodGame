namespace Utilities
{
    public static class Debugger
    {
        public static void Log(string message)
        {
#if DEBUG_ENABLED
            UnityEngine.Debug.Log(message);
#endif
        }

        public static void LogWarning(string message)
        {
#if DEBUG_ENABLED
            UnityEngine.Debug.LogWarning(message);
#endif
        }

        public static void LogError(string message)
        {
#if DEBUG_ENABLED
            UnityEngine.Debug.LogError(message);
#endif
        }
    }
}