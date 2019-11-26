using System.Collections;
using System.Collections.Generic;
using UnityEngine;
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

    // Todo: Maybe make generic 'Enemy' class for type safety
    private List<GameObject> enemies = new List<GameObject>();

    public void Awake()
    {
        // Maintain only one instantiation of Instance at a time
        if (Instance == null)
            Instance = this;
        else if (Instance != this)
            Destroy(gameObject);

        DontDestroyOnLoad(gameObject);

        levelTextOverlay = GameObject.Find("LevelTextOverlay");
        levelText = GameObject.Find("LevelText").GetComponent<Text>();

        InitNextLevel();
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
    }
}
