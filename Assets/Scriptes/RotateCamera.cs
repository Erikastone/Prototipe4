using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateCamera : MonoBehaviour
{
    public float rotationSpeed; //поворот камеры
    private float inputHorizontal;
    void Start()
    {
        
    }


    void Update()
    {
        RotateCameras();
    }

    void RotateCameras()
    {
        inputHorizontal = Input.GetAxis("Horizontal");
        transform.Rotate(Vector3.up, inputHorizontal * rotationSpeed * Time.deltaTime);
    }
}
