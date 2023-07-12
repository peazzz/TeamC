using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageFullRotation : MonoBehaviour
{
    public float rotationSpeed = 50f;

    private void Update()
    {
        // Rotate the sprite around the y-axis
        transform.Rotate(Vector3.up, rotationSpeed * Time.deltaTime);
    }
}
