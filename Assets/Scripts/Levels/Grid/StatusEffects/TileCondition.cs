using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class TileCondition
{
    public TileStatus State; //the status effect
    public int Duration; //time that the effect will be active
    public bool CanTriggerOtherEffects; // can trigger other effects ?

    public TileCondition(TileStatus a_state, int a_duration, bool a_isTrigger)
    {
        State = a_state;
        Duration = a_duration;
        CanTriggerOtherEffects = a_isTrigger;
    }

    public void Tick()
    {
        Duration--;
    }

    public bool IsExpired()
    {
        return Duration <= 0;
    }
}