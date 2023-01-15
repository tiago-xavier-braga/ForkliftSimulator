using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float liftSpeed = 2f;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 moveLift;
    private PlayerInputActions inputActions;
    public GameObject lift;

    private float maxLiftY = 2f;
    private float minLiftY = 0.1f;

    public Rigidbody rb;


    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    private void FixedUpdate()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
        moveLift = inputActions.PlayerControls.Lift.ReadValue<Vector2>();

        if (moveInput.x != 0)
        {
            transform.Rotate(Vector3.up, rotateSpeed * moveInput.x * Time.deltaTime);
        }
        if (moveInput.y != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * moveInput.y);
        }

        if (moveLift.y > 0f)
        {
            if (lift.transform.position.y < maxLiftY)
            {
                lift.transform.Translate(Vector3.up * Time.deltaTime * liftSpeed * moveLift.y);
            }
        }
        if (moveLift.y < 0f)
        {
            if (lift.transform.position.y > minLiftY)
            {
                lift.transform.Translate(Vector3.up * Time.deltaTime * liftSpeed * moveLift.y);
            }
        }
    }
}
