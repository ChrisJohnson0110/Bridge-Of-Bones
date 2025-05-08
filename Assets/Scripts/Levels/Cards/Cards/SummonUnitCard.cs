using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/SummonUnitCard")]
public class SummonUnitCard : UnitCard
{
    public GameObject unitPrefab;
    public int attack;
    public int health;
    public override void PlayCard()
    {

    }

    public override void PlayCard(Vector3 a_positon)
    {
        //summoning logic
    }

}