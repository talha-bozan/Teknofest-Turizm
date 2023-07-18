using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateAroundObject : MonoBehaviour
{
    public GameObject target; // The target game object to rotate around
    private float rotationSpeed = 1000.0f; // The speed of rotation

    private void Update()
    {
        if (target == null)
        {
            Debug.LogWarning("No target game object assigned for rotation.");
            return;
        }

        // Calculate the rotation vector
        float rotationAngle = rotationSpeed * Time.deltaTime;

        // Apply the rotation to the game object
        transform.Rotate(rotationAngle, 0, 0);

    }
}
