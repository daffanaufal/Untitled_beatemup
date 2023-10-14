using UnityEngine;
using System.Collections;

public class Spawner : MonoBehaviour 
{
	public Transform[] SpawnPoints;
	public Wave[] waves;
	public enemy Enemy;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;
	
//------------GameObject------------
    public GameObject Floor;

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Player")
		{
			NextWave();
			//Destroy(gameObject,5f);
			gameObject.GetComponent<BoxCollider>().enabled=false;
		}
	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
			
			//Random Position Spawn
			int spawnIndex=Random.Range(0, SpawnPoints.Length);
			enemy spawnedEnemy = Instantiate(Enemy, SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation) as enemy;
			
			spawnedEnemy.OnDeath += OnEnemyDeath;
		}
	}

	void OnEnemyDeath() {
		enemiesRemainingAlive --;

		if (enemiesRemainingAlive == 0) {
			NextWave();
			NextFloor();
		}
	}

	void NextFloor()
	{
		Floor.GetComponent<Collider>().enabled=false;
		print ("Next Floor");
	}


	void NextWave() {
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