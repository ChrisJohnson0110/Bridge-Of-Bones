using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridTile
{
    public Vector2Int tileCoordinates { get; private set; }
    public Vector3 worldPos { get; private set; }
    public float tileHeight { get; private set; }
    public bool IsLandPassable { get; set; }
    public bool IsAirPassable { get; set; }
    public List<BaseUnit> UnitsOccupyingTile { get; private set; }
    public List<TileCondition> tileConditions { get; private set; }

    //constructor //tile setup
    public GridTile(Vector2Int a_coordinates, Vector3 a_worldPosition, float a_height, bool a_isLandPassable, bool a_isAirPassable)
    {
        tileCoordinates = a_coordinates;
        worldPos = a_worldPosition;
        tileHeight = a_height;
        IsLandPassable = a_isLandPassable;
        IsAirPassable = a_isAirPassable;

        UnitsOccupyingTile = new List<BaseUnit>();
        tileConditions = new List<TileCondition>();
    }

    //add a unit to this tile
    public void AddUnit(BaseUnit a_unit)
    {
        if (UnitsOccupyingTile.Contains(a_unit) == false)
        {
            UnitsOccupyingTile.Add(a_unit);
        }
    }

    //remove a unit from this tile
    public void RemoveUnit(BaseUnit a_unit)
    {
        UnitsOccupyingTile.Remove(a_unit);
    }

    public void AddCondition(TileCondition a_condition)
    {
        tileConditions.Add(a_condition);
    }

    //update the status effects on the ground of this tile
    public void UpdateConditions()
    {
        for (int i = tileConditions.Count - 1; i >= 0; i--)
        {
            TileCondition condition = tileConditions[i];
            condition.Tick();

            if (condition.IsExpired())
            {
                tileConditions.RemoveAt(i);
            }
        }
        
        CheckForTileInteractions();
    }

    //remove a status condition from this tile
    public void RemoveCondition(TileCondition a_condition)
    {
        tileConditions.Remove(a_condition);
    }

    //get if this tile is passable
    public bool IsPassableFor(BaseUnit a_unit)
    {
        if (a_unit.IsFlying == true)
        {
            return IsAirPassable;
        }
        else
        {
            return IsLandPassable;
        }
    }

    // check for interactions e.g. fire&oil
    private void CheckForTileInteractions()
    {
        //for each status effect check if it matches onfire then coveredin oil
        bool isOnFire = tileConditions.Any(c => c.State == TileState.OnFire);
        bool isOilPresent = tileConditions.Any(c => c.State == TileState.CoveredInOil);

        if (isOnFire == true && isOilPresent == true)
        {
            Debug.Log($"Explosion at {tileCoordinates}");
            HandleGridInteractions.instance.TriggerExplosion(this);
        }
    }
}