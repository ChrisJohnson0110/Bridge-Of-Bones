using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class MapNodeDisplay : MonoBehaviour
{
    public static MapNodeDisplay instance;

    [Header("pop up fields")]
    [SerializeField] private GameObject _display;
    [SerializeField] private TMP_Text _levelName;
    [SerializeField] private Image _levelImage;
    [SerializeField] private TMP_Text _highscore;
    [SerializeField] private TMP_Text _timeTaken;
    [SerializeField] private TMP_Text _unitsUsed;
    [SerializeField] private TMP_Text _completionRating;

    [Header("pop up offset")]
    [SerializeField] private Vector3 _offset = new Vector3(0,1,0);

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);

        _display.SetActive(false);
    }

    public void UpdateDisplay(MapNode a_nodeToDisplay, bool a_shouldBeActive)
    {
        if (a_shouldBeActive == false)
        {
            _display.SetActive(false);
            return;
        }

        _display.SetActive(true);

        _levelName.text = a_nodeToDisplay.mapData.displayName;
        _levelImage.sprite = a_nodeToDisplay.mapData.coverImage;
        _highscore.text = PlayerProgress.instance.GetLevelHighscore(a_nodeToDisplay.mapData.mapID).ToString();
        _timeTaken.text = PlayerProgress.instance.GetLevelBestTime(a_nodeToDisplay.mapData.mapID).ToString();
        _unitsUsed.text = PlayerProgress.instance.GetLevelBestUnits(a_nodeToDisplay.mapData.mapID).ToString();
        _completionRating.text = PlayerProgress.instance.GetLevelCompletionRate(a_nodeToDisplay.mapData.mapID).ToString();

        gameObject.transform.position = a_nodeToDisplay.gameObject.transform.position + _offset;
    }
}
