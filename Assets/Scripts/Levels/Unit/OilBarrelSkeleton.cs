using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class OilBarrelSkeleton : BaseUnit
{
    private void OnMove(Vector2Int newTile)
    {
        GridTile cell = GridManager.instance.GetCell(newTile);

        if (cell != null)
        {
            bool isOnFire = cell.tileConditions.Any(c => c.State == TileStatus.OnFire);

            if (isOnFire)
            {
                Explode();
            }
        }
    }

    private void Explode()
    {
        Debug.Log($"{unitName} explodes, causing an area of effect explosion!");

        Vector2Int currentTile = new Vector2Int((int)transform.position.x, (int)transform.position.z);
        List<GridTile> adjacentCells = GridManager.instance.GetAdjacentCells(currentTile);

        foreach (GridTile cell in adjacentCells)
        {
            foreach (BaseUnit unit in cell.UnitsOccupyingTile)
            {
                unit.TakeDamage(30);
                Debug.Log($"{unit.unitName} takes 30 damage from the explosion!");
            }
        }

        // Destroy self
        Destroy(gameObject);
    }
}
