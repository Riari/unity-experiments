using System;
using System.Collections.Generic;
using UnityEngine;

public class Car : MonoBehaviour
{
    [SerializeField]
    private GameObject waypointsContainer;

    private List<Vector3> waypoints = new List<Vector3>();

    private int targetWaypointIndex = 0;
    private float targetMagnitude = 0.5f;

    private float movementSpeed = 5.0f;
    private float rotationSpeed = 5.0f;

    // Start is called before the first frame update
    void Start()
    {
        // Just assume everything inside waypointsContainer is to be treated as a waypoint
        for (int i = 0; i < waypointsContainer.transform.childCount; ++i)
        {
            Vector3 child = waypointsContainer.transform.GetChild(i).transform.position;
            waypoints.Add(child);
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Get waypoint
        Vector3 targetWaypoint = waypoints[targetWaypointIndex];

        // Rotate towards it
        Vector3 directionToTarget = targetWaypoint - transform.position;
        float targetAngle = Mathf.Atan2(directionToTarget.y, directionToTarget.x) * Mathf.Rad2Deg;
        Quaternion targetRotation = Quaternion.Euler(0f, 0f, targetAngle);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        // Move forward
        transform.position += transform.right * Time.deltaTime * movementSpeed;

        // Update waypoint if necessary
        Vector3 difference = transform.position - targetWaypoint;
        if (difference.magnitude <= targetMagnitude) ++targetWaypointIndex;
        if (targetWaypointIndex >= waypoints.Count) targetWaypointIndex = 0;
    }
}
