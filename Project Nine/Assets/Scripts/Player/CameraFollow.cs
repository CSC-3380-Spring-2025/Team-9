using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    // Creates variables for the camera speed and the target (the player)
    public float FollowSpeed = 2f;
    public Transform target;

    void Update()
    {
        // Creates a new position vector for the camera, using the target's x and y position
        // z is set so the camera is positioned correctly in a 2D space
        Vector3 newPos = new Vector3(target.position.x, target.position.y, -10f);

        // Smoothly moves the camera to the new position using spherical imterpolation (Slerp)
        transform.position = Vector3.Slerp(transform.position, newPos, FollowSpeed * Time.deltaTime);
    }
}
