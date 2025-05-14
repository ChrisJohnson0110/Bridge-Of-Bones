using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitPlacement : MonoBehaviour
{
    public static UnitPlacement instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    //should be a create unit within the unit
    public void PlaceUnit(BaseUnit unit, Vector2Int targetTile)
    {
        GridTile cell = GridManager.instance.GetCell(targetTile);

        if (cell == null)
        {
            Debug.LogWarning("Invalid tile position.");
            return;
        }

        if (cell.IsPassableFor(unit))
        {
            cell.AddUnit(unit);
            unit.transform.position = cell.worldPos;
        }
        else
        {
            Debug.LogWarning("Tile is not passable for " + unit.UnitName);
        }
    }

    public void MoveUnit(BaseUnit unit, Vector2Int targetTile)
    {
        Vector2Int currentTile = new Vector2Int((int)unit.transform.position.x, (int)unit.transform.position.z);
        GridTile currentCell = GridManager.instance.GetCell(currentTile);
        GridTile targetCell = GridManager.instance.GetCell(targetTile);

        if (currentCell != null)
        {
            currentCell.RemoveUnit(unit);
        }

        if (targetCell != null && targetCell.IsPassableFor(unit))
        {
            targetCell.AddUnit(unit);
            unit.transform.position = targetCell.worldPos;
        }
    }
}