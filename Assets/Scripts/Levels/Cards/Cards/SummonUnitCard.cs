using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/SummonUnitCard")]
public class SummonUnitCard : Card
{
    public GameObject unitPrefab;
    public int attack;
    public int health;

    public override void PlayCard()
    {
        //summoning logic
    }
}