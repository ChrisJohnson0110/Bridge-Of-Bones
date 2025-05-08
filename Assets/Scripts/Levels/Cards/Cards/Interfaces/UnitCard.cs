using UnityEngine;

[System.Serializable]
public abstract class UnitCard : Card, InterfaceUnitCard
{
    public abstract void PlayCard(Vector3 position);
}