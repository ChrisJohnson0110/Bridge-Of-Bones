using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedProjectile : IAttackBehavior
{
    public void Attack(BaseUnit unit, List<BaseUnit> targets, AbilityBase ability)
    {
        if (targets == null || ability == null) return;

        BaseUnit target;

        if (targets.Count == 1)
        {
            target = targets[0];
        }
        else
        {
            float distance = int.MaxValue; //not a fan of maxvalue
            foreach (BaseUnit bu in targets)
            {
                if (Vector2Int.Distance(unit.occupiedTilePosition, bu.occupiedTilePosition) < distance (out float f))
                {
                    distance = ;
                }
            }
        }

        

        if (distance <= unit.range)
        {
            ability.Execute(unit, targets);
            Debug.Log($"{unit.unitName} executed {ability.abilityName} on {targets.unitName}");
        }
        else
        {
            Debug.Log($"{unit.unitName} is out of range to attack {targets.unitName}");
        }
    }


    private bool IsWithinDistance(Vector2Int pos1, Vector2Int pos2, float threshold, out float distance)
    {
        distance = Vector2Int.Distance(pos1, pos2);
        return distance < threshold;
    }
}