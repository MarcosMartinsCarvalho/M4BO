using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementScriptCrircle : MonoBehaviour
{
    [SerializeField] private Transform pointA;         // Point A
    [SerializeField] private float radius = 5f;        // Radius of the circular path
    [SerializeField] private float angularSpeed = 1f;  // Angular speed of the circular motion
    [SerializeField] private float currentAngle = 0f;  // Current angle of rotation

    void Start()
    {
        // Set the initial position of the object at point A
        transform.position = pointA.position;
    }

    void Update()
    {
        // Update the current angle based on angular speed
        currentAngle += angularSpeed * Time.deltaTime;

        // Calculate the new position using polar coordinates
        float x = pointA.position.x + radius * Mathf.Cos(currentAngle);
        float y = pointA.position.y + radius * Mathf.Sin(currentAngle);
        Vector3 newPosition = new Vector3(x, y, 0f);

        // Move the object to the new position
        transform.position = newPosition;
    }
}
