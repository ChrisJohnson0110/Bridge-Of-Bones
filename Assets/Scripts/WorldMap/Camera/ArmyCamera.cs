using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyCamera : MonoBehaviour
{
    public static ArmyCamera instance;

    [SerializeField] private Transform _armyObject;
    [SerializeField] private Vector3 _followOffset = new Vector3(0f, 5f, -10f);
    [SerializeField] private float _freeLookSpeed = 20f;

    private bool _isCameraMovementEnabled = false;
    private bool _isFreeLook = false;
    private Vector3 _originalRotationEuler;

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        if (_armyObject == null)
        {
            enabled = false;
            return;
        }

        _originalRotationEuler = transform.rotation.eulerAngles;
    }

    void LateUpdate()
    {
        if (_isCameraMovementEnabled == true)
        {
            if (!_isFreeLook)
            {
                HandleLockedCamera();
            }
            else
            {
                HandleFreeCamera();
            }
        }
    }

    private void HandleLockedCamera()
    {
        transform.position = _armyObject.position + _followOffset;
        transform.rotation = Quaternion.Euler(_originalRotationEuler);
    }

    private void HandleFreeCamera()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 moveDir = new Vector3(horizontal, 0f, vertical).normalized;
        transform.position += moveDir * _freeLookSpeed * Time.deltaTime;

        transform.rotation = Quaternion.Euler(_originalRotationEuler);
    }

    public void EnableCameraMovement()
    {
        _isCameraMovementEnabled = true;
    }

    public bool ToggleFreeLookEnabled()
    {
        _isFreeLook = !_isFreeLook;
        return _isFreeLook;
    }


}
