using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpriteRotate : MonoBehaviour
{
   public float rotationSpeed = 50f;
    private bool rotateClockwise = true;
    private float currentRotation = 0f;

    private void Update()
    {
        // Rotate the object
        if (rotateClockwise)
        {
            transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
            currentRotation += rotationSpeed * Time.deltaTime;
        }
        else
        {
            transform.Rotate(Vector3.down, rotationSpeed * Time.deltaTime);
            currentRotation -= rotationSpeed * Time.deltaTime;
        }

        // Check if reached the desired rotation
        if (currentRotation >= 30f)
        {
            rotateClockwise = false;
        }
        else if (currentRotation <= -15f)
        {
            rotateClockwise = true;
        }
    } 
}
