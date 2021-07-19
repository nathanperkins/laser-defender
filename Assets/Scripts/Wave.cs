using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Enemy Wave Config")]
public class Wave : ScriptableObject
{
    [SerializeField] GameObject pathPrefab;
    [SerializeField] GameObject enemyPrefab;
    [SerializeField] float timeBetweenSpawns;
    [SerializeField] float spawnRandomFactor;
    [SerializeField] int numberOfEnemies;
    [SerializeField] float enemyMoveSpeed;


    public List<Vector3> GetWaypoints() {
        var waypoints = new List<Vector3>();
        foreach(Transform waypoint in pathPrefab.transform) {
            waypoints.Add(waypoint.position);
		}
        return waypoints;
	}

    public GameObject GetPath() { return pathPrefab; }
    public float GetTimeBetweenSpawns() { return timeBetweenSpawns; }
    public float GetSpawnRandomFactor() { return spawnRandomFactor; }
    public int GetNumberOfEnemies() { return numberOfEnemies; }
    public float GetEnemyMoveSpeed() { return enemyMoveSpeed; }
}
