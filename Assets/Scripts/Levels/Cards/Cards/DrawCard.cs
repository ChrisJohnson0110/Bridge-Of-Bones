using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Cards/DrawCard")]
public class DrawCard : Card
{
    public int drawAmount;
    public DrawType drawType;

    public override void PlayCard()
    {
        //damage logic
    }
}
