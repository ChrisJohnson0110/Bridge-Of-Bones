using UnityEngine;

public enum TileStatus
{
    Normal,
    OnFire,
    CoveredInOil,
    Frozen,
    Electrified,
    Wet
}

public enum Directions
{
    North,
    South,
    East,
    West
}

public static class HelperFunctionsEnums
{
    public static Vector3 GetDirection(Directions direction)
    {
        switch (direction)
        {
            case Directions.North:
                return Vector3.forward;    // (0, 0, 1)
            case Directions.South:
                return Vector3.back;       // (0, 0, -1)
            case Directions.East:
                return Vector3.right;      // (1, 0, 0)
            case Directions.West:
                return Vector3.left;       // (-1, 0, 0)
            default:
                return Vector3.zero;       // (0, 0, 0)
        }
    }
}