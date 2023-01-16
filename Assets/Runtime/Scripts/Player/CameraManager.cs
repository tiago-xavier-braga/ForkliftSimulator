using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class CameraManager : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera firstCM;
    [SerializeField] CinemachineVirtualCamera rightCM;
    [SerializeField] CinemachineVirtualCamera leftCM;
    private PlayerInputActions inputActions;
    private bool isRight = false;
    private bool isLeft = false;
    private bool isFirst = false;

    private void Awake()
    {
        inputActions = new PlayerInputActions();
        inputActions.PlayerControls.Enable();
        inputActions.PlayerControls.Camera.performed += onCamereInput;
    }

    private void onCamereInput(InputAction.CallbackContext obj)
    {
        
        if (obj.control.name == "v")
        {
            if (isFirst == false)
            {
                Debug.Log(obj.control.name);
                firstCM.m_Priority = 10;
                rightCM.m_Priority = 0;
                leftCM.m_Priority = 0;
                isRight = false;
                isLeft = false;
                isFirst = true;
            }
            else if (isFirst == true)
            {
                firstCM.m_Priority = 0;
                isRight = false;
                isLeft = false;
                isFirst = false;
            }
        }
        if (obj.control.name == "q")
        {
            if (isLeft == false)
            {
                firstCM.m_Priority = 0;
                rightCM.m_Priority = 0;
                leftCM.m_Priority = 10;
                isRight = false;
                isLeft = true;
                isFirst = false;
            }
            else if (isLeft == true)
            {
                leftCM.m_Priority = 0;
                isRight = false;
                isLeft = false;
                isFirst = false;
            }
        }
        if (obj.control.name == "e")
        {
            if (isRight == false)
            {
                firstCM.m_Priority = 0;
                rightCM.m_Priority = 10;
                leftCM.m_Priority = 0;
                isRight = true;
                isLeft = false;
                isFirst = false;
            }
            else if (isRight == true)
            {
                rightCM.m_Priority = 0;
                isRight = false;
                isLeft = false;
                isFirst = false;
            }
        }
    }
}
