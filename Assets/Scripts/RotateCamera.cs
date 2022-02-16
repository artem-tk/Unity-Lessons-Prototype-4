using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float RotationSpeed;

    void Start()
    {
        
    }

    void Update()
    {
        float HorizontalInput = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, HorizontalInput * RotationSpeed * Time.deltaTime);
    }
}
