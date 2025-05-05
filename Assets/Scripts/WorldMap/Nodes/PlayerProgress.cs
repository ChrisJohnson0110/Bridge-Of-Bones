using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerProgress : MonoBehaviour
{
    public static PlayerProgress instance;

    public Dictionary<string, int> scores = new Dictionary<string, int>();
    public Dictionary<string, float> bestTimes = new Dictionary<string, float>();
    public Dictionary<string, int> bestUnits = new Dictionary<string, int>();
    public Dictionary<string, int> skullRatings = new Dictionary<string, int>();

    void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
        DontDestroyOnLoad(gameObject);

        //load data here
    }

    public void SaveCompletion(string mapID, float time, int units, int skulls)
    {
        scores[mapID] = Mathf.Max(scores.ContainsKey(mapID) ? scores[mapID] : 0, skulls * 100);
        bestTimes[mapID] = Mathf.Min(bestTimes.ContainsKey(mapID) ? bestTimes[mapID] : float.MaxValue, time);
        bestUnits[mapID] = Mathf.Min(bestUnits.ContainsKey(mapID) ? bestUnits[mapID] : int.MaxValue, units);
        skullRatings[mapID] = Mathf.Max(skullRatings.ContainsKey(mapID) ? skullRatings[mapID] : 0, skulls);
    }
}