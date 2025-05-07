using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/EnviromentCard")]
public class EnviromentCard : Card
{
    public float modifierAmount;
    EnviromentChanges modifierType;

    public override void PlayCard()
    {
        //damage logic
    }
}
