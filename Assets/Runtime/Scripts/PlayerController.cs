using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float turnSpeed = 20f;
    [SerializeField] private Vector2 moveInput;
    [SerializeField] private Vector2 moveLift;
    private PlayerInputActions inputActions;
    public GameObject lift;

    private float maxLiftY = 8f;
    private float minLiftY = 2.7f;


    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    private void Update()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();
        moveLift = inputActions.PlayerControls.Lift.ReadValue<Vector2>();

        if (moveInput.x != 0)
        {
            transform.Rotate(Vector3.up, turnSpeed * moveInput.x * Time.deltaTime);
        }
        if (moveInput.y != 0)
        {
            transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * moveInput.y);
        }

        if (moveLift.y > 0f)
        {
            if (lift.transform.position.y < maxLiftY)
            {
                lift.transform.Translate(Vector3.up * Time.deltaTime * 10 * moveLift.y);
                Debug.Log(lift.transform.position.y);
            }
        }
        if (moveLift.y < 0f)
        {
            if (lift.transform.position.y > minLiftY)
            {
                lift.transform.Translate(Vector3.up * Time.deltaTime * 10 * moveLift.y);
                Debug.Log(lift.transform.position.y);
            }
        }
    }
}
