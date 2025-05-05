using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Army : MonoBehaviour
{
    public static Army instance;

    public bool isArmyMovable { get; private set; } = false;
    public bool isCameraInFreeLook { get; private set; } = false;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    private void Update()
    {
        if (isArmyMovable == true)
        {
            ArmyMovement.instance.HandleMovement();
            ArmyMovement.instance.HandleRotation();
        }

        if (Input.GetKeyDown(KeyCode.C))
        {
            ToggleFreeLook();
        }
    }

    public void ToggleFreeLook()
    {
        bool cameraFreelook = ArmyCamera.instance.ToggleFreeLookEnabled();

        if (cameraFreelook == true)
        {
            DisableArmyControls();
        }
        else if (cameraFreelook == false)
        {
            EnableArmyControls();
        }
    }

    public void EnableArmyControls()
    {
        isArmyMovable = true;
    }
    public void DisableArmyControls()
    {
        isArmyMovable = false;
    }

}
