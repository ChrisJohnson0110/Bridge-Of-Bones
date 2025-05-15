using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitController : MonoBehaviour
{
    public List<BaseUnit> allUnits = new List<BaseUnit>();

    void Update()
    {
        foreach (BaseUnit unit in allUnits)
        {
            EvaluateUnitAction(unit);
        }
    }

    private void EvaluateUnitAction(BaseUnit unit)
    {
        // Check for targets in range
        BaseUnit target = FindTargetInRange(unit);

        if (target != null)
        {
            unit.ExecuteAttack(target);
        }
        else
        {
            // If no target, decide where to move
            Vector2Int nextTile = DetermineNextTile(unit);
            unit.ExecuteMove(nextTile);
        }
    }

    private BaseUnit FindTargetInRange(BaseUnit unit)
    {
        float range = unit.range;

        foreach (BaseUnit otherUnit in allUnits)
        {
            if (otherUnit != unit)
            {
                float distance = Vector2Int.Distance(unit.occupiedTilePosition, otherUnit.occupiedTilePosition);

                if (distance <= range)
                {
                    return otherUnit;
                }
            }
        }

        return null;
    }

    private Vector2Int DetermineNextTile(BaseUnit unit)
    {
        // Placeholder: Move forward one tile
        return unit.occupiedTilePosition + Vector2Int.up;
    }
}