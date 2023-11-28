using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class callMinion : MonoBehaviour
{
    public Wave[] waves;
	public enemy Enemy;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;

	void Start() {
		//NextWave ();
	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;

			enemy spawnedEnemy = Instantiate(Enemy, Vector3.zero, Quaternion.identity) as enemy;
			spawnedEnemy.OnDeath += OnEnemyDeath;
		}
	}

	void OnEnemyDeath() {
		enemiesRemainingAlive --;

		if (enemiesRemainingAlive == 0) {
			NextWave();
		}
	}

	public void NextWave() {
		currentWaveNumber ++;
		print ("Wave: " + currentWaveNumber);
		if (currentWaveNumber - 1 < waves.Length) {
			currentWave = waves [currentWaveNumber - 1];

			enemiesRemainingToSpawn = currentWave.enemyCount;
			enemiesRemainingAlive = enemiesRemainingToSpawn;
		}
	}

	[System.Serializable]
	public class Wave {
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}