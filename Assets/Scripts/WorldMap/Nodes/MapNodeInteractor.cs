using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapNodeInteractor : MonoBehaviour
{
    private MapNode currentNode;

    private void OnTriggerEnter(Collider other)
    {
        var node = other.GetComponent<MapNode>();
        if (node != null && node.IsUnlocked())
        {
            currentNode = node;
            MapNodeDisplay.instance.UpdateDisplay(currentNode, true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.GetComponent<MapNode>() == currentNode)
        {
            currentNode = null;
            MapNodeDisplay.instance.UpdateDisplay(currentNode, false);
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
