using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/HealSpellCard")]
public class HealSpellCard : Card
{
    public int heal;
    public CardAbilityType abilityType;

    public override void PlayCard()
    {
        //damage logic
    }
}
