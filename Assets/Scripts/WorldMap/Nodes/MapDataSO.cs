using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "Maps/Map Data")]
public class MapDataSO : ScriptableObject
{
    [Header("Basic Info")]
    public string mapID;
    public string displayName;
    public string sceneName;
    public Sprite coverImage;

    [Header("Unlock Requirement")]
    public UnlockRequirement unlockRequirement;

    [Header("Completion Info")]
    public float bestTime;
    public int unitsUsed;
    public int skullRating;

    public bool IsUnlocked(Dictionary<string, int> playerScores)
    {
        if (unlockRequirement == null)
            return true;

        if (playerScores.TryGetValue(unlockRequirement.requiredMapID, out int score))
        {
            return score >= unlockRequirement.requiredScore;
        }

        return false;
    }
}
