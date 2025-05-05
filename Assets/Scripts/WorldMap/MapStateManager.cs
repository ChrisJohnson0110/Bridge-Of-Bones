using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapStateManager : MonoBehaviour
{
    void Start()
    {
        Army.instance.EnableArmyControls();
        ArmyCamera.instance.EnableCameraMovement();
    }

}
