using UnityEngine;

public class DebugManager : Singleton<DebugManager>
{
    public bool debugPlatforms = false;

    public void DebugString(string _debug)
    {
        Debug.Log($"DEBUG_LOG : {_debug}");
    }

    public void DebugWarning(string _warning)
    {
        Debug.LogWarning($"DEBUG_WARNING : {_warning}");
    }

    public void DebugError(string _error)
    {
        Debug.LogError($"DEBUG_ERROR : {_error}");
    }
}