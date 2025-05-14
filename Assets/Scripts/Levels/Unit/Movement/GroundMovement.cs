using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour, IMovable
{
    private BaseUnit unit;

    private void Awake()
    {
        unit = GetComponent<BaseUnit>();
    }

    public void Move(Vector2Int targetTile)
    {
        if (!unit.IsStationary)
        {
            // Implement ground movement logic here
            Debug.Log($"{unit.UnitName} moves to {targetTile}");
        }
    }
}