using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public abstract class Card : ScriptableObject, InterfaceCard
{
    [Header("Card base details")]
    public string cardName;
    public Sprite cardImage;
    public Sprite cardBackground;
    public string description;
    public int cost;

    [Header("")]
    public bool isUnlocked = false;

    public abstract void PlayCard();
}