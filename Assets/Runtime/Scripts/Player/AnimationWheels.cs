 using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationWheels : MonoBehaviour
{
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private float rotateSpeed = 600f;
    [SerializeField] private GameObject wheelFrontLeft;
    [SerializeField] private GameObject wheelFrontRight;
    [SerializeField] private GameObject wheelRearLeft;
    [SerializeField] private GameObject wheelRearRight;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    private void Update()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();

        if (moveInput.y != 0)
        {
            wheelFrontLeft.transform.Rotate(Vector3.right, rotateSpeed * moveInput.y);
            wheelFrontRight.transform.Rotate(Vector3.right, rotateSpeed * moveInput.y);
            wheelRearLeft.transform.Rotate(Vector3.right, rotateSpeed * moveInput.y);
            wheelRearRight.transform.Rotate(Vector3.right, rotateSpeed * moveInput.y);
        }
    }
}
