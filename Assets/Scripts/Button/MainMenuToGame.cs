using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class MainMenuToGame : MonoBehaviour
{
    public void TaskOnClick()
    {
        SceneManager.LoadScene(1);
    }
}
