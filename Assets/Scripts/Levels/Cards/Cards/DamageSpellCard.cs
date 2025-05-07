using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DamageSpellCard")]
public class DamageSpellCard : Card
{
    public int damage;
    public CardAbilityType abilityType;

    public override void PlayCard()
    {
        //damage logic
    }
}
