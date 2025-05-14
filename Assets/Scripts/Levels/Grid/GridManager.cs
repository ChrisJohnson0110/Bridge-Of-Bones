using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//grid creation and management
public class GridManager : MonoBehaviour
{
    public static GridManager instance;

    [Header("Grid Settings")]
    [SerializeField] private int _gridWidth = 10;
    [SerializeField] private int _gridHeight = 10;
    [SerializeField] private float _cellSize = 1f;

    [SerializeField] private GameObject _tilePrefab;

    private Grid _mainGrid; //the game grid

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        GenerateGrid(); //create the grid
        InvokeRepeating("UpdateTileConditions", 0f, 1f);// update status conditions every second / every tick
    }

    public void GenerateGrid()
    {
        // Prepare height, land passability, and air passability data
        float[,] heights = new float[_gridWidth, _gridHeight];
        bool[,] landPassable = new bool[_gridWidth, _gridHeight];
        bool[,] airPassable = new bool[_gridWidth, _gridHeight];

        for (int x = 0; x < _gridWidth; x++)
        {
            for (int y = 0; y < _gridHeight; y++)
            {
                heights[x, y] = 0f;  // Default flat height
                landPassable[x, y] = true;  // Default passable terrain
                airPassable[x, y] = true;  // Default passable for air

                Vector3 worldPosition = new Vector3(x * _cellSize, 0, y * _cellSize);

                Instantiate(_tilePrefab, worldPosition, Quaternion.identity);  // Create tile visuals
            }
        }

        // Use the new Grid class to manage the tile data
        _mainGrid = new Grid(_gridWidth, _gridHeight, heights, landPassable, airPassable);

        Debug.Log("Grid Generated using Grid class with " + (_gridWidth * _gridHeight) + " cells.");
    }

    // get the tile at a given position
    public GridTile GetCell(Vector2Int a_coordinates)
    {
        return _mainGrid.GetCell(a_coordinates);
    }

    // update tile conditions
    public void UpdateTileConditions()
    {
        _mainGrid.UpdateAllConditions();
    }

    // get adjacent cells
    public List<GridTile> GetAdjacentCells(Vector2Int a_coordinates)
    {
        return _mainGrid.GetAdjacentCells(a_coordinates);
    }
}