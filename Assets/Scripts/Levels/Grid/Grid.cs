using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Grid
{
    private Dictionary<Vector2Int, GridTile> tiles;

    //create a grid of positions
    public Grid(int a_width, int a_height, float[,] a_heights, bool[,] a_landPassable, bool[,] a_airPassable)
    {
        tiles = new Dictionary<Vector2Int, GridTile>();

        for (int x = 0; x < a_width; x++)
        {
            for (int y = 0; y < a_height; y++)
            {
                Vector2Int coordinates = new Vector2Int(x, y);
                Vector3 position = new Vector3(x, a_heights[x, y], y);

                tiles[coordinates] = new GridTile(coordinates, position, a_heights[x, y], a_landPassable[x, y], a_airPassable[x, y]);
            }
        }
    }

    //get the tile at given coords
    public GridTile GetCell(Vector2Int a_coordinates)
    {
        this.tiles.TryGetValue(a_coordinates, out GridTile tile);

        return tile;
    }

    //update all tiles conditions
    public void UpdateAllConditions()
    {
        foreach (var tile in tiles.Values)
        {
            tile.UpdateConditions();
        }
    }

    //get the tiles adjacent to the given coords
    public List<GridTile> GetAdjacentCells(Vector2Int coordinates)
    {
        List<GridTile> adjacentCells = new List<GridTile>();
        Vector2Int[] directions = {
            Vector2Int.up, Vector2Int.down, Vector2Int.left, Vector2Int.right
        };

        foreach (Vector2Int direction in directions)
        {
            Vector2Int adjacentCoords = coordinates + direction;
            if (tiles.TryGetValue(adjacentCoords, out GridTile adjacentTile))
            {
                adjacentCells.Add(adjacentTile);
            }
        }

        return adjacentCells;
    }
}