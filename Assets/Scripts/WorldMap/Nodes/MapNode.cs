using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapNode : MonoBehaviour
{
    public MapDataSO mapData;
    public MapNode unlockSourceNode;

    [SerializeField] private GameObject _visualLocked;
    [SerializeField] private GameObject _visualUnlocked;
    [SerializeField] private bool _shouldBeUnlocked;

    private LineRenderer _lineRenderer;

    void Start()
    {
        UpdateVisuals();
        DrawConnectionLine();
    }

    public bool IsUnlocked()
    {
        if (_shouldBeUnlocked == true)
        {
            return true;
        }
        return mapData.IsUnlocked(PlayerProgress.instance.highscores);
    }

    private void UpdateVisuals()
    {
        bool unlocked = IsUnlocked();

        if (_visualLocked != null)
        {
            _visualLocked.SetActive(!unlocked);
        }
        if (_visualUnlocked != null)
        {
            _visualUnlocked.SetActive(unlocked);
        }
    }

    private void DrawConnectionLine()
    {
        if (unlockSourceNode == null) return;

        GameObject lineObj = new GameObject("UnlockLine");
        lineObj.transform.SetParent(this.transform);

        _lineRenderer = lineObj.AddComponent<LineRenderer>();
        _lineRenderer.positionCount = 2;
        _lineRenderer.SetPosition(0, unlockSourceNode.transform.position);
        _lineRenderer.SetPosition(1, transform.position);

        _lineRenderer.widthMultiplier = 0.1f;

        if (IsUnlocked())
        {
            _lineRenderer.material = MapGraphMaterials.Instance.unlockedMaterial;
        }
        else
        {
            _lineRenderer.material = MapGraphMaterials.Instance.lockedMaterial;
        }

        _lineRenderer.useWorldSpace = true;
    }

    public void Interact()
    {
        if (IsUnlocked())
        {
            SceneManager.LoadScene(mapData.sceneName);
        }
        else
        {
            Debug.Log("Level is locked.");
        }
    }

}
