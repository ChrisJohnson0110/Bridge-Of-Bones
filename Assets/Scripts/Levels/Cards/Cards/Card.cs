using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Card : ScriptableObject
{
    [Header("Card base details")]
    public string cardName;
    public CardType cardType;
    public Sprite cardImage;
    public Sprite cardBackground;
    public string description;
    public int cost;

    public abstract void PlayCard();
}