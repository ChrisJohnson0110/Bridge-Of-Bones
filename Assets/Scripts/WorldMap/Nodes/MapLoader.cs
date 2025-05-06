using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapLoader : MonoBehaviour
{
    public static MapLoader instance;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    public void LoadMap(MapDataSO mapData)
    {
        if (!mapData.IsUnlocked(PlayerProgress.instance.highscores))
        {
            Debug.Log("Map is locked.");
            return;
        }

        SceneManager.LoadScene(mapData.sceneName);
    }
}
