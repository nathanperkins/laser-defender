using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Wave[] waves;

    int currentWaveIndex = 0;

    // Start is called before the first frame update
    void Start()
    {
        var currentWave = waves[currentWaveIndex];
        StartCoroutine(SpawnAllEnemiesInWave(currentWave));
    }

    private IEnumerator SpawnAllEnemiesInWave(Wave wave)
	{
        for (int enemyCount = 0; enemyCount < wave.GetNumberOfEnemies(); enemyCount++)
		{
            GameObject newEnemy = Instantiate(
				wave.GetEnemyPrefab(),
				wave.GetWaypoints()[0],
				Quaternion.identity);
            newEnemy.GetComponent<EnemyPathing>().SetWave(wave);

			yield return new WaitForSeconds(wave.GetTimeBetweenSpawns());
		}
	}
}
