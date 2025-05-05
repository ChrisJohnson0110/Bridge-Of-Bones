using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeInteractor : MonoBehaviour
{
    [SerializeField] private GameObject interactionPromptUI;

    private MapNode currentNode;

    private void OnTriggerEnter(Collider other)
    {
        var node = other.GetComponent<MapNode>();
        if (node != null && node.IsUnlocked())
        {
            currentNode = node;
            if (interactionPromptUI) interactionPromptUI.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MapNode>() == currentNode)
        {
            currentNode = null;
            if (interactionPromptUI) interactionPromptUI.SetActive(false);
        }
    }

    void Update()
    {
        if (currentNode != null && Input.GetKeyDown(KeyCode.E))
        {
            currentNode.Interact();
        }
    }
}
