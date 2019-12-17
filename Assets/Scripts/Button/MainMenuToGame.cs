using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuToGame : MonoBehaviour
{
    public void Click_StartGame()
    {
        SceneManager.LoadScene(1);
    }

    public void Click_ExitGame()
    {
        Application.Quit();
    }
}
