using System.Collections;
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
    // Start is called before the first frame update
    void Start()
    {
        enemyCurrentWave = enemyStartWave;
    }

    // Update is called once per frame

    public void Spawn()
    {
        
        enemiesLeftCurrentWave = enemyCurrentWave;
        
        while (enemiesLeftCurrentWave >= 0)
        {
            
            Vector3 pos = new Vector3(Random.Range(xMin, xMax), Random.Range(yMin, yMax), 0);
            int randomEnemy = Random.Range(0, enemies.Length);

            GameObject newEnemey = Instantiate(enemies[randomEnemy], pos, Quaternion.identity);
            GameManager.Instance.SpawnEnemies(newEnemey);
            enemiesLeftCurrentWave -= enemyValue[randomEnemy];
            Debug.Log(enemies[randomEnemy]);

        }

        enemyCurrentWave += enemyIncreasePerWave;

    }

}
