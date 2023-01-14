using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 5f;
    [SerializeField] private float rotateSpeed = 10f;
    [SerializeField] private float liftSpeed = 2f;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 moveLift;
    [SerializeField] private Rigidbody rb;
    private PlayerInputActions inputActions;
    public GameObject lift;

    private float maxLiftY = 2f;
    private float minLiftY = 0.1f;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
        rb = GetComponent<Rigidbody>();
    }

    private void Update()
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
            //rb.velocity = Vector3.forward * moveInput * turnSpeed * Time.deltaTime;
        }

        if (moveLift.y > 0f)
        {
            if (lift.transform.position.y < maxLiftY)
            {
                lift.transform.Translate(Vector3.up * Time.deltaTime * liftSpeed * moveLift.y);
                Debug.Log(lift.transform.position.y);
            }
        }
        if (moveLift.y < 0f)
        {
            if (lift.transform.position.y > minLiftY)
            {
                lift.transform.Translate(Vector3.up * Time.deltaTime * liftSpeed * moveLift.y);
                Debug.Log(lift.transform.position.y);
            }
        }
    }
}
