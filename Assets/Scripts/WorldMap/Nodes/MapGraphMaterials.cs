using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapGraphMaterials : MonoBehaviour
{
    public static MapGraphMaterials Instance;

    public Material unlockedMaterial;
    public Material lockedMaterial;

    void Awake()
    {
        if (Instance != null && Instance != this)
            Destroy(gameObject);
        else
            Instance = this;
    }
}
