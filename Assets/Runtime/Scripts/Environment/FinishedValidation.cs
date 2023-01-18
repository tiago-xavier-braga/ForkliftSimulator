using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class FinishedValidation : MonoBehaviour
{
    public GameObject player;

    private void Update()
    {
        if (Math.Round(player.transform.position.x) == Math.Round(this.transform.position.x) && Math.Round(player.transform.position.y) == Math.Round(this.transform.position.y) && Math.Round(player.transform.position.z) == Math.Round(this.transform.position.z))
        {
            SceneManager.LoadScene("CongratulationsScene");
        }
    }
}
