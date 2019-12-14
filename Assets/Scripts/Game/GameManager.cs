using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    // Making the class into a semi-singleton
    public static GameManager Instance = null;

    public float levelStartDelay = 1f;
    public float levelTextFadeDelay = 1f;

    private GameObject levelTextOverlay;
    private Text levelText;
    private int level = 0;
    private EnemySpawner spawner;
    
    private bool isRunning = false;
    private GameObject gameOverOverlay;
    private Text gameOverText;

    // Todo: Maybe make generic 'Enemy' class for type safety
    private List<GameObject> enemies = new List<GameObject>();

    public void Awake()
    {
        // Maintain only one instantiation of Instance at a time
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        InitGameManager();
    }

    private void InitGameManager()
    {
        enemies.Clear();
        isRunning = true;
        spawner = GameObject.Find("Spawner").GetComponent<EnemySpawner>();
        levelTextOverlay = GameObject.Find("LevelTextOverlay");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        gameOverOverlay = GameObject.Find("GameOver");
        gameOverText = GameObject.Find("GameOverHelpText").GetComponent<Text>();
        gameOverOverlay.SetActive(false);

        InitNextLevel();
        spawner.Spawn();
    }

    public void Update()
    {
        if (isRunning)
            return;

        if (Input.GetKeyUp(KeyCode.Space))
        {
            // Reload scene
            Debug.Log("Restarting scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        else if (Input.GetKeyUp(KeyCode.Escape))
        {
            // Exit or go to main screen?

        }
    }

    public void InitNextLevel()
    {
        ++level;
        levelText.text = "Wave " + level;
        levelTextOverlay.SetActive(true);
        Invoke(nameof(HideLevelText), levelStartDelay);
    }

    private void HideLevelText()
    {
        StartCoroutine(LevelTextFadeOut());
    }

    private IEnumerator LevelTextFadeOut()
    {
        var originalColor = levelText.color;
        for (float t = 0f; t < levelTextFadeDelay; t += Time.deltaTime)
        {
            levelText.color = Color.Lerp(originalColor, Color.clear, Mathf.Min(1, t / levelTextFadeDelay));
            yield return null;
        }

        levelTextOverlay.SetActive(false);
        levelText.color = originalColor;
    }

    public void EnemyDead(GameObject enemy)
    {
        enemies.Remove(enemy);
        if (enemies.Count == 0)
        {
            InitNextLevel();
            spawner.Spawn();
        }
    }
    public void SpawnEnemies(GameObject enemy)
    {
        enemies.Add(enemy);
    }

    public void PlayerDied()
    {
        isRunning = false;

        gameOverText.text = gameOverText.text
            .Replace("%WAVE%", level.ToString())
            .Replace("%RESTARTKEY%", "\"space\"")
            .Replace("%QUITKEY%", "\"escape\"");
        gameOverOverlay.SetActive(true);
    }
}
