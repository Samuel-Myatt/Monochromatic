using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawnerScript : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject EnemyPrefab;
    public GameObject EnemyPlusPrefab;
    public GameObject menuCurrent;
    public GameObject menuBlack;
    public GameObject menuWhite;
    public GameObject UI;
    public int enemiesActive = 0;
    public int frequency = 100;
    public int delay = 1000;
    public int numToSpawn = 10;
    public int numToSpawnStatic;
    public bool inRound = true;
    public int roundCount = 1;
    public int time;
    public float enemySpeed = 2;
    // Start is called before the first frame update
    void Start()
    {
        numToSpawnStatic = numToSpawn;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

	private void FixedUpdate()
	{
        if (numToSpawn > 0)
        {
            time++;
            if (time >= delay)
            {

                SpawnEnemy();
                ResetTimer();
                numToSpawn -= 1;
            }
        }
        else if(inRound && enemiesActive == 0)
		{
            EndRound();

        }
        
    }

    void EndRound()
	{
        inRound = false;
        menuCurrent.SetActive(true);
        Time.timeScale = 0f;
        UI.GetComponent<UIScript>().paused = true;
    }

    public void ResetRound()
	{
        inRound = true;
        numToSpawnStatic += Random.Range(3, 10);
        numToSpawn = numToSpawnStatic;
        frequency += 5;
        time = 0;
        menuCurrent.SetActive(false);
        Time.timeScale = 1f;
        UI.GetComponent<UIScript>().paused = false;
        UI.GetComponent<UIScript>().IncreaseRound();
        enemySpeed += 0.3f;
        roundCount++;
    }

	void ResetTimer()
	{
        time = Random.Range(frequency, 100);
	}

    void SpawnEnemy()
	{
        int randSpawnPoint = Random.Range(0, spawnPoints.Length);
        if(Random.RandomRange(0,10) > 7)
		{
            Instantiate(EnemyPlusPrefab, spawnPoints[randSpawnPoint]);
        }
        else
		{
            Instantiate(EnemyPrefab, spawnPoints[randSpawnPoint]);
        }
        
        enemiesActive++;
	}
    public void ReduceEnemySpeed()
	{
        enemySpeed -= 0.6f;
        ResetRound();
	}
}
