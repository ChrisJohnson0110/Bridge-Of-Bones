using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelStateManager : MonoBehaviour
{
    void Start()
    {
        DeckHandManager.instance.StartGame();
    }
}
