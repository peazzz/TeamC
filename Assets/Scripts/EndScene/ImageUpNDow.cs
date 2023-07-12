using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImageUpNDow : MonoBehaviour
{
    public float moveSpeed = 1.0f;
    public float moveDistance = 1.0f;

    private Vector3 startPosition;
    private float timer = 0.0f;
    private bool movingUp = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // Update the timer
        timer += Time.deltaTime * moveSpeed;

        // Calculate the new position based on the current direction
        Vector3 newPosition = startPosition;
        newPosition.y += Mathf.Sin(timer) * moveDistance;
        newPosition.y += transform.parent.transform.position.y;

        // Move the sprite to the new position
        transform.position = newPosition;

        // Toggle the direction when reaching the top or bottom of the movement range
        if (timer >= Mathf.PI * 2)
        {
            timer = 0.0f;
            movingUp = !movingUp;
        }
    } 
}
