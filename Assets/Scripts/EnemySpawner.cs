using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] Wave[] waves;

    // Start is called before the first frame update
    void Start()
    {
		StartCoroutine(SpawnAllWaves());
    }

    private IEnumerator SpawnAllWaves() { 
        for (int waveCount = 0; waveCount < waves.Length; waveCount++) { 
			var currentWave = waves[waveCount];
			yield return StartCoroutine(SpawnAllEnemiesInWave(currentWave));
		}
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
