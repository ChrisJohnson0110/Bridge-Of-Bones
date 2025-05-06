using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "NewMapData", menuName = "Maps/Map Data")]
public class CardData : ScriptableObject
{
    [Header("Basic Info")]
    public string cardID;
    public string displayName;
    public Sprite cardSpriteImage;
    public Sprite cardBackgroundImage;

    //background would change with card type

    //type
    //attacker - any units that attack

    //kinda the same 
    //utility - heal for x, draw 2, freeze enemy units 
    //effect - ability you can cast e.g. all units move faster, deal 10 dmg to a unit, summon thunder cloud, 

    //

    //card class
    //all card types inherit from this class
    //each type // catagory
    
    //attackercard : card

    //card
    //use
    
}
