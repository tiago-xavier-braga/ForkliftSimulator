using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectiveValidation : MonoBehaviour
{
    public GameObject box;
    public GameObject gate;

    private void Update()
    {
        if (Math.Round(box.transform.position.x) == Math.Round(this.transform.position.x) && Math.Round(box.transform.position.y) == Math.Round(this.transform.position.y) && Math.Round(box.transform.position.z) == Math.Round(this.transform.position.z))
        {
            Debug.Log(gate.transform.rotation.z);
            if (gate.transform.rotation.z > -0.7f)
            {
                gate.transform.Rotate(Vector3.back, 10f * Time.deltaTime);
            }

        }
    }
}
