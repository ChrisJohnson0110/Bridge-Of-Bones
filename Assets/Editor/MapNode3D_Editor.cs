#if UNITY_EDITOR
using UnityEngine;
using UnityEditor;
using System.Collections.Generic;

[CustomEditor(typeof(MapNode))]
public class MapNode3D_Editor : Editor
{
    [MenuItem("Tools/MapNodes/Auto-Link Map Node Connections")]
    public static void AutoLinkNodes()
    {
        MapNode[] allNodes = GameObject.FindObjectsOfType<MapNode>();
        Dictionary<string, MapNode> nodeLookup = new();

        foreach (var node in allNodes)
        {
            if (node.mapData != null && !string.IsNullOrEmpty(node.mapData.mapID))
            {
                nodeLookup[node.mapData.mapID] = node;
            }
        }

        int linked = 0;
        foreach (var node in allNodes)
        {
            if (node.mapData != null && node.mapData.unlockRequirement != null)
            {
                string requiredID = node.mapData.unlockRequirement.requiredMapID;
                if (nodeLookup.TryGetValue(requiredID, out var sourceNode))
                {
                    Undo.RecordObject(node, "Auto-Link Unlock Source Node");
                    node.unlockSourceNode = sourceNode;
                    linked++;
                }
            }
        }

        Debug.Log($"[MapGraph] Auto-linked {linked} node connections.");
    }
}
#endif
