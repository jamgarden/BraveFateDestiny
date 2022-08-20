using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Manager_Game : MonoBehaviour
{
    public static Manager_Game Instance;

    void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            Instance = this;
        }
    }

    public void MainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void WinGame()
    {
        SceneManager.LoadScene("WinGame");
    }

    public void GamePlay()
    {
        SceneManager.LoadScene("Gameplay");
    }

    public void GameOver()
    {
        SceneManager.LoadScene("GameOver");
    }
}
