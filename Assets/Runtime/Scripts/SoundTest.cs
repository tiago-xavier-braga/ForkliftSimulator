using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class SoundTest : MonoBehaviour
{
    [SerializeField] private AudioSource reverse;

    public void PlaySound()
    {
        reverse.loop = true;
        reverse.Play();
    }
}
