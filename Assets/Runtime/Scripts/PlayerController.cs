using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 20f;
    [SerializeField] private Vector2 moveInput;
    private PlayerInputActions inputActions;
    public float horizontalInput;
    public float forwardInput;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    private void Update()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();

        if (moveInput.x != 0)
        {
            horizontalInput = moveInput.x;
            transform.Rotate(Vector3.up, turnSpeed * moveInput.x * Time.deltaTime);
        }
        if (moveInput.y != 0)
        {
            forwardInput= moveInput.y;
            transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * moveInput.y);
        }
        /*
        transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * forwardInput);
        transform.Rotate(Vector3.up, turnSpeed * horizontalInput * Time.deltaTime);*/
    }
}
