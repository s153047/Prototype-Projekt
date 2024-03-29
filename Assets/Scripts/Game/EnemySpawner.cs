﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int enemyStartWave;
    public int enemyCurrentWave;
    public int enemiesLeftCurrentWave;
    public int enemyIncreasePerWave;
    public GameObject[] enemies;
    public float xMin;
    public float xMax;
    public float yMin;
    public float yMax;
    public int[] enemyValue;

    void Awake()
    {
        enemyCurrentWave = enemyStartWave;
    }


    public void Spawn()
    {
        // If no enemies are set up to spawn, just return
        if (enemies.Length <= 0)
        {
            Debug.Log("No enemies set to spawn in the spawner");
            return;
        }
            

        enemiesLeftCurrentWave = enemyCurrentWave;
        
        while (enemiesLeftCurrentWave >= 0)
        {
            
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
            int randomEnemy = Random.Range(0, enemies.Length);


            GameObject newEnemy = Instantiate(enemies[randomEnemy], pos, Quaternion.identity);
            GameManager.Instance.SpawnEnemies(newEnemy);
            enemiesLeftCurrentWave -= enemyValue[randomEnemy];

        }

        enemyCurrentWave += enemyIncreasePerWave;

    }

}
