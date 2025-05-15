using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MeleeMove : IMoveBehavior
{
    public void Move(BaseUnit unit, Vector2Int targetTile)
    {
        if (unit.isStationary)
        {
            Debug.Log($"{unit.unitName} is stationary and cannot move.");
            return;
        }

        unit.Move(targetTile);
    }
}
