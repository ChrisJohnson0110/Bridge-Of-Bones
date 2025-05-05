using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmyMovement : MonoBehaviour
{
    public static ArmyMovement instance;

    [SerializeField] private float _moveSpeed = 5f;
    [SerializeField] private float _accelerationTime = 0.1f;
    [SerializeField] private float _rotationSpeed = 20f;

    private Camera mainCamera;

    private Rigidbody _rigidbodyReference;
    private Vector3 _currentVelocity;
    private Vector3 _desiredVelocity;
    private float _velocitySmoothTime;

    //TODO PLANNED FUTURE MOVEMENT
    //wasd controls a vector 2 pos for a ray cast position
    //ray cast down onto map
    //army pos = hit pos

    private void Awake()
    {
        if (instance == null) instance = this;
        else Destroy(gameObject);
    }

    void Start()
    {
        _rigidbodyReference = GetComponent<Rigidbody>();
        mainCamera = Camera.main;
        _velocitySmoothTime = _accelerationTime;
    }
    public void HandleMovement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        Vector3 inputDir = new Vector3(horizontal, 0f, vertical).normalized;

        if (inputDir != Vector3.zero)
        {
            Vector3 camForward = mainCamera.transform.forward;
            Vector3 camRight = mainCamera.transform.right;

            camForward.y = 0;
            camRight.y = 0;

            camForward.Normalize();
            camRight.Normalize();

            _desiredVelocity = (camForward * inputDir.z + camRight * inputDir.x) * _moveSpeed;
        }
        else
        {
            _desiredVelocity = Vector3.zero;
        }

        _currentVelocity = Vector3.Lerp(_currentVelocity, _desiredVelocity, Time.fixedDeltaTime / _velocitySmoothTime);
        _rigidbodyReference.velocity = new Vector3(_currentVelocity.x, _rigidbodyReference.velocity.y, _currentVelocity.z);
    }

    public void HandleRotation()
    {
        Vector3 flatVelocity = _rigidbodyReference.velocity;
        flatVelocity.y = 0;

        if (flatVelocity.sqrMagnitude > 0.01f)
        {
            Quaternion targetRotation = Quaternion.LookRotation(flatVelocity);
            _rigidbodyReference.MoveRotation(Quaternion.Slerp(_rigidbodyReference.rotation, targetRotation, _rotationSpeed * Time.fixedDeltaTime));
        }
    }
}
