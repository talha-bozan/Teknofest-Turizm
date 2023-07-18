using UnityEngine;
using System.Collections.Generic;

public class AutoPilot : MonoBehaviour
{
    public List<Transform> waypoints;
    public float speed = 5f;
    public float turnSpeed = 5f;
    public float arrivalDistance = 1f;

    private int currentWaypointIndex = 0;

    private void Update()
    {
        if (waypoints.Count == 0) return;

        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
        float distanceToWaypoint = targetDirection.magnitude;

        // Check if the airplane has arrived at the waypoint
        if (distanceToWaypoint <= arrivalDistance)
        {
            // Move to the next waypoint
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Count)
            {
                currentWaypointIndex = 0; // Loop back to the first waypoint
            }
        }
        else
        {
            // Move towards the waypoint
            Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, turnSpeed * Time.deltaTime);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
    }
}
