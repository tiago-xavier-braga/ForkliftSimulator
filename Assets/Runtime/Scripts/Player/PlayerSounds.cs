using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerSounds : MonoBehaviour
{
    [SerializeField] private AudioSource engineAudioSourceForklift;
    [SerializeField] private AudioSource reverseAudioSourceForklift;
    [SerializeField] private AudioSource forwardAudioSourceForklift;

    private Vector2 moveInput;
    private PlayerInputActions inputActions;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
    }

    private void Update()
    {
        moveInput = inputActions.PlayerControls.Movement.ReadValue<Vector2>();

        if (moveInput.y < 0)
        {
            if (!reverseAudioSourceForklift.isPlaying)
            {
                reverseAudioSourceForklift.Play();
                forwardAudioSourceForklift.Stop();
            }
        }

        if (moveInput.y > 0)
        {
            if (!forwardAudioSourceForklift.isPlaying)
            {
                forwardAudioSourceForklift.Play();
                reverseAudioSourceForklift.Stop();
            }
        }
        if (moveInput == new Vector2(0,0))
        {
            forwardAudioSourceForklift.Stop();
            reverseAudioSourceForklift.Stop();
        }
        /*if (moveInput.y != 0)
        {
            //transform.Translate(Vector3.forward * Time.deltaTime * turnSpeed * moveInput.y);
            if (moveInput.y < 0)
            {
                //reverseCar.loop = true;
                //reverseCar.Play();
                forwardCar.Stop();
                if (!reverseCar.isPlaying)
                {
                    reverseCar.PlayOneShot(reverseCarAudioClip);
                }
            }
            else
            {
                reverseCar.Stop();
                forwardCar.PlayOneShot();
            }
            /*
            else if (moveInput.y > 0)
            {
                reverseCar.Stop();
                forwardCar.Play();
            }
            else if (moveInput.y != 1 && moveInput.x != 1)
            {
                reverseCar.Stop();
                forwardCar.Stop();
                //stopCar.Stop();
            }
        }*/
    }
}
