using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotationAnimation : MonoBehaviour
{
    private float rotation;
    public float RotationSpeed;
    public bool clockWiseRotations;
  

    // Update is called once per frame
    void Update()
    {
        if (clockWiseRotations == false)
        {
            rotation += Time.deltaTime * RotationSpeed;

        }
        else {
            rotation -= Time.deltaTime * RotationSpeed;
        
        }
        transform.rotation = Quaternion.Euler(0, 0, rotation);
    }
}
