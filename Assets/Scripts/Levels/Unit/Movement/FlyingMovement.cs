using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingMovement : MonoBehaviour, IMovable
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
            Debug.Log($"{unit.UnitName} flies to {targetTile}");
        }
    }
}