using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnerFloor2 : MonoBehaviour
{
    public Transform[] SpawnPoints;
	public Wave[] waves;
	public GameObject[] Enemy;

	Wave currentWave;
	int currentWaveNumber;

	int enemiesRemainingToSpawn;
	int enemiesRemainingAlive;
	float nextSpawnTime;
	
//------------GameObject------------
    public GameObject nextFloor;
	public GameObject gateFloor;

	void start()
	{
		gateFloor.GetComponent<Collider>().enabled=false;
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.tag=="Player")
		{
			NextWave();
			//Destroy(gameObject,5f);
			gameObject.GetComponent<BoxCollider>().enabled=false;
			gateFloor.GetComponent<Collider>().enabled=true;
		}
	}

	void Update() {

		if (enemiesRemainingToSpawn > 0 && Time.time > nextSpawnTime) {
			enemiesRemainingToSpawn--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
			
			//Random Position Spawn
			int spawnIndex=Random.Range(0, SpawnPoints.Length);
			int objIndex=Random.Range(0, Enemy.Length);
			
            GameObject enemyObject = Instantiate(Enemy[objIndex], SpawnPoints[spawnIndex].position, SpawnPoints[spawnIndex].rotation);
            enemy spawnedEnemy = enemyObject.GetComponent<enemy>();
			
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
		nextFloor.GetComponent<Collider>().enabled=false;
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
