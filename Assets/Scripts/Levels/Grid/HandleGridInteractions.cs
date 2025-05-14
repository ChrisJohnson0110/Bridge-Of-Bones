using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HandleGridInteractions : MonoBehaviour
{
    public static HandleGridInteractions instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    //trigger explosion
    public void TriggerExplosion(GridTile a_gridTile)
    {
        foreach (BaseUnit unit in a_gridTile.UnitsOccupyingTile)
        {
            unit.TakeDamage(50);
            Debug.Log($"{unit.UnitName} takes 50 damage from explosion!");
        }
        //remove status effects
        a_gridTile.tileConditions.RemoveAll(c => c.State == TileStatus.CoveredInOil);
    }
}
