using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    void Start()
    {
        DeckHandManager.instance.StartGame();
        GridManager.instance.GenerateGrid();
        InvokeRepeating("GameTick", 0f, 1f);// update status conditions every second / every tick


        //TODO

        //account for start up ?

        //start wave spawning
    }

    private void GameTick()
    {
        GridManager.instance.UpdateTileConditions();
        UnitController.instance.Tick();
    }
}
