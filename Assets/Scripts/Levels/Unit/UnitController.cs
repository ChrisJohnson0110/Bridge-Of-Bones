using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public static UnitController instance;
    public List<BaseUnit> allUnits = new List<BaseUnit>();

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void Tick()
    {
        foreach (BaseUnit unit in allUnits)
        {
            EvaluateUnitAction(unit);
        }
    }

    private void EvaluateUnitAction(BaseUnit unit)
    {
        List<BaseUnit> targets = FindTargetInRange(unit);

        if (targets != null)
        {
            unit.PerformBasicAttack(targets);
        }
        else
        {
            Vector2Int nextTile = DetermineNextTile(unit);
            unit.Move(nextTile);
        }
    }

    private List<BaseUnit> FindTargetInRange(BaseUnit unit)
    {
        List<BaseUnit> baseUnitsWithinRange = new List<BaseUnit>();

        foreach (BaseUnit otherUnit in allUnits)
        {
            if (otherUnit != unit)
            {
                float distance = Vector2Int.Distance(unit.occupiedTilePosition, otherUnit.occupiedTilePosition);

                if (distance <= unit.range)
                {
                    baseUnitsWithinRange.Add(otherUnit);
                }
            }
        }

        return baseUnitsWithinRange;
    }

    private Vector2Int DetermineNextTile(BaseUnit unit)
    {
        return unit.occupiedTilePosition + Vector2Int.up; // Move forward by default
    }
}