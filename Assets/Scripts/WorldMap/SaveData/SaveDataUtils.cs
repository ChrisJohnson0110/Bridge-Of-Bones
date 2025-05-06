using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class SaveDataUtils
{
    public static T GetLevelData<T>(Dictionary<string, T> a_dict, string levelID, T defaultValue = default)
    {
        if (a_dict.TryGetValue(levelID, out T value))
        {
            return value;
        }
        return defaultValue;
    }
}