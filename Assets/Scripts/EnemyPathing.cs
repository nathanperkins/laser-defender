using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] GameObject path;
    [SerializeField] float moveSpeed;
    [SerializeField] bool enableLogging;

    List<Vector3> waypoints = new List<Vector3>();
    int waypointIndex = 0;

    void Start()
    {
        SetWaypointsFromPath();
        transform.position = waypoints[waypointIndex];
        NextWaypoint();
    }

    void Update()
    {
        Move();
    }

    private void Move() { 
        if (waypointIndex < waypoints.Count)
		{
            var targetPos = waypoints[waypointIndex];
            var movementThisFrame = moveSpeed * Time.deltaTime;
            var newPos = Vector2.MoveTowards(transform.position, targetPos, movementThisFrame);
            transform.position = newPos;
            if (transform.position == targetPos) {
                NextWaypoint();
			}
		}
		else
		{
            if (enableLogging) {
                Debug.Log("Destroying enemy " + gameObject.name);
            }
            Destroy(gameObject);
		}
	}

    private void SetWaypointsFromPath()
	{ 
        var points = path.GetComponentsInChildren<Transform>();
        for (int i = 1; i < points.Length; i++) {
            var point = points[i];
			waypoints.Add(point.transform.position);
		}
        if (enableLogging) {
            Debug.Log("Found " + waypoints.Count + " waypoints for enemy " + gameObject.name);
		}
	}

    private void NextWaypoint()
	{ 
		waypointIndex++;
        if (enableLogging) {
            Debug.Log("Moving enemy " + gameObject.name + " toward waypoint " + waypointIndex);
		}
	}
}
