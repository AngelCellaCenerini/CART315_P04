using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{

    public float rotationSpeedX = 0.1f;
    public float rotationSpeedY = 0.1f;
    public float rotationSpeedZ = 0.1f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.GetComponent<Transform>().Rotate(rotationSpeedX, rotationSpeedY, rotationSpeedZ);
    }
}
