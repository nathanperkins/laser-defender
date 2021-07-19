using System.Collections.Generic;
using UnityEngine;

public class EnemyPathing : MonoBehaviour
{
    [SerializeField] Wave wave;
    [SerializeField] float moveSpeed;
    [SerializeField] bool enableLogging;

    List<Vector3> waypoints;
    int waypointIndex = 0;

    void Start()
    {
        waypoints = wave.GetWaypoints();
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

    private void NextWaypoint()
	{ 
		waypointIndex++;
        if (enableLogging) {
            Debug.Log("Moving enemy " + gameObject.name + " toward waypoint " + waypointIndex);
		}
	}
}
