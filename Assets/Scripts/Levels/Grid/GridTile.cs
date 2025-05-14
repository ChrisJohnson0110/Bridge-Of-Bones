using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class GridTile
{
    public Vector2Int tileCoordinates { get; private set; } // tile coords
    public Vector3 worldPos { get; private set; } // position within the scene
    public float tileHeight { get; private set; } // height of the tile
    public bool IsLandPassable { get; set; } // can be passed by land units
    public bool IsAirPassable { get; set; } //can be passed by air units
    public List<BaseUnit> UnitsOccupyingTile { get; private set; } // list of units on tile
    public List<TileCondition> tileConditions { get; private set; } // status conditions on tile
    public float TotalOccupiedSpace { get; private set; }  // total space occupied on the tile
    public float MaxTileSpace { get; private set; }  // max available space per tile


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

        TotalOccupiedSpace = 0f;  
        MaxTileSpace = 1f;

    }

    //add a unit to this tile
    public bool AddUnit(BaseUnit a_unit)
    {
        if (TotalOccupiedSpace + a_unit.SpaceOccupied <= MaxTileSpace)  // Check if there's enough space
        {
            UnitsOccupyingTile.Add(a_unit);
            TotalOccupiedSpace += a_unit.SpaceOccupied;  // Increase occupied space by the unit's space
            return true;  // Successfully added the unit
        }
        else
        {
            Debug.LogWarning($"Not enough space to add unit to tile {tileCoordinates}");
            return false;  // Not enough space
        }
    }

    //remove a unit from this tile
    public void RemoveUnit(BaseUnit a_unit)
    {
        if (UnitsOccupyingTile.Contains(a_unit))
        {
            UnitsOccupyingTile.Remove(a_unit);
            TotalOccupiedSpace -= a_unit.SpaceOccupied;  // Decrease occupied space by the units space
        }
    }

    //add a status condition to the tile
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

        bool isFrozen = tileConditions.Any(c => c.State == TileState.Frozen);
        bool isElectrified = tileConditions.Any(c => c.State == TileState.Electrified);

        if (isOnFire == true && isOilPresent == true)
        {
            Debug.Log($"Explosion at {tileCoordinates}");
            HandleGridInteractions.instance.TriggerExplosion(this);
        }
    }
}