using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private Dictionary<Vector2Int, GridTile> tile;

    //create a grid of positions
    public Grid(int a_width, int a_height, float[,] a_heights, bool[,] a_landPassable, bool[,] a_airPassable)
    {
        tile = new Dictionary<Vector2Int, GridTile>();

        for (int x = 0; x < a_width; x++)
        {
            for (int y = 0; y < a_height; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                Vector3 position = new Vector3(x, a_heights[x, y], y);

                tile[coordinates] = new GridTile(coordinates, position, a_heights[x, y], a_landPassable[x, y], a_airPassable[x, y]);
            }
        }
    }

    //get the tile at given coords
    public GridTile GetCell(Vector2Int a_coordinates)
    {
        this.tile.TryGetValue(a_coordinates, out GridTile tile);

        return tile;
    }

    //update all tiles conditions
    public void UpdateAllConditions()
    {
        foreach (var tile in tile.Values)
        {
            tile.UpdateConditions();
        }
    }
}