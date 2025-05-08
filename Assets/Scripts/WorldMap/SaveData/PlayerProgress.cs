using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance;

    //level data //levelID, value
    public Dictionary<string, int> highscores = new Dictionary<string, int>();
    public Dictionary<string, float> bestTimes = new Dictionary<string, float>();
    public Dictionary<string, int> bestUnits = new Dictionary<string, int>();
    public Dictionary<string, int> completionRate = new Dictionary<string, int>();

    //card data //CardID, value
    public Dictionary<string, bool> cardUnlocks = new Dictionary<string, bool>();

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        //load data here
    }

    #region Level 
    public void SaveCompletionLevel(string a_mapID, float a_time, int a_units, int a_completionRate)
    {
        //SCORE
        if (highscores.ContainsKey(a_mapID))
        {
            int currentScore = highscores[a_mapID];
            highscores[a_mapID] = Mathf.Max(currentScore, a_completionRate);
        }
        else
        {
            highscores[a_mapID] = a_completionRate;
        }

        //TIME
        if (bestTimes.ContainsKey(a_mapID))
        {
            float currentBestTime = bestTimes[a_mapID];
            bestTimes[a_mapID] = Mathf.Min(currentBestTime, a_time);
        }
        else
        {
            bestTimes[a_mapID] = a_time;
        }

        //UNITS
        if (bestUnits.ContainsKey(a_mapID))
        {
            int currentBest = bestUnits[a_mapID];
            bestUnits[a_mapID] = Mathf.Min(currentBest, a_units);
        }
        else
        {
            bestUnits[a_mapID] = a_units;
        }

        //RATING
        if (completionRate.ContainsKey(a_mapID))
        {
            int currentRating = completionRate[a_mapID];
            completionRate[a_mapID] = Mathf.Max(currentRating, Mathf.RoundToInt(a_completionRate / 3));
        }
        else
        {
            completionRate[a_mapID] = Mathf.RoundToInt(a_completionRate / 3);
        }
    }

    public int GetLevelHighscore(string a_levelID)
    {
        return SaveDataUtils.GetLevelData(highscores, a_levelID);
    }

    public float GetLevelBestTime(string a_levelID)
    {
        return SaveDataUtils.GetLevelData(bestTimes, a_levelID);
    }

    public int GetLevelBestUnits(string a_levelID)
    {
        return SaveDataUtils.GetLevelData(bestUnits, a_levelID);
    }

    public int GetLevelCompletionRate(string a_levelID)
    {
        return SaveDataUtils.GetLevelData(completionRate, a_levelID);
    }
    #endregion

    #region Card 
    //return a string list of all cards that have been unlocked
    public List<string> GetCardUnlock()
    {
        return SaveDataUtils.GetUnlockedCards(cardUnlocks);
    }


    #endregion

}