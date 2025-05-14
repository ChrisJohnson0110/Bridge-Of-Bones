using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Unit
{
    public string Name { get; private set; }
    public List<Vector2Int> OccupiedTiles { get; private set; }
    public bool IsFlying { get; private set; }

    public Unit(string name, List<Vector2Int> occupiedTiles, bool isFlying)
    {
        Name = name;
        OccupiedTiles = occupiedTiles;
        IsFlying = isFlying;
    }
}