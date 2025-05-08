using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

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

    public static List<string> GetUnlockedCards(Dictionary<string, bool> cardUnlocks)
    {
        List<string> unlockedCards = new List<string>();

        if (cardUnlocks == null)
        {
            return unlockedCards;
        }

        foreach (KeyValuePair<string, bool> pair in cardUnlocks)
        {
            if (pair.Value)
            {
                unlockedCards.Add(pair.Key);
            }
        }

        return unlockedCards;
    }
}