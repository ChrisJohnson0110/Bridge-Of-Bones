using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Unit", menuName = "Units/Unit Data")]
public class UnitData : ScriptableObject
{
    [Header("Unit Attributes")]
    public string UnitName;
    public float MaxHP;
    public float Damage;
    public float MoveSpeed;
    public float Range;
    public bool IsFlying;
    public bool IsStationary;
    public Vector2Int OccupiedTilesSize;
    public float SpaceOccupied; // amount of tile space the unit takes

    [Header("Abilities")]
    public AbilityBase BasicAttack; // normal attack
    public AbilityBase SpecialAbility; // optional special ability

    public GameObject unitPrefab; //units model
}
