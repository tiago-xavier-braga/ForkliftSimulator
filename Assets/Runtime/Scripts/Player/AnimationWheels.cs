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

    private float maxRotateY = 0.9f;
    private float minRotateY = 0.35f;

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
        /*
        if (transform.rotation.y < maxRotateY)
        {
            transform.Rotate(Vector3.up, 60f * moveInput.x * Time.deltaTime);
        }
        if (transform.rotation.y > minRotateY)
        {
            transform.Rotate(Vector3.up, 60f * moveInput.x * Time.deltaTime);
        }*/

        if (moveInput.y != 0)
        {
            if (moveInput.x > 0f)
        {
            if (wheelFrontLeft.transform.rotation.y > minRotateY)
            {
                wheelFrontRight.transform.Rotate(Vector3.up, 60f * moveInput.x * Time.deltaTime);
                wheelFrontLeft.transform.Rotate(Vector3.up, 60f * moveInput.x * Time.deltaTime);
            }
        }
        if (moveInput.x < 0f)
        {
            if (wheelFrontLeft.transform.rotation.y < maxRotateY)
            {
                wheelFrontRight.transform.Rotate(Vector3.up, 60f * moveInput.x * Time.deltaTime);
                wheelFrontLeft.transform.Rotate(Vector3.up, 60f * moveInput.x * Time.deltaTime);
            }
        }
        }
        

        /*
        if (moveInput.y == 0f)
        {
            if (wheelFrontLeft.transform.rotation.y < maxRotateY)
            {
                wheelFrontRight.transform.Rotate(0f, 0f, 0f, Space.World);
                wheelFrontLeft.transform.Rotate(0f, 0f, 0f, Space.World);
            }
        }*/
    }
}
