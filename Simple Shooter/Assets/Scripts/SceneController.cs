using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    private enum Scenes
    {
        MainMenu = 0,
        Game = 1,
        Retry = 2
    }

    public void StartGame()
    {
        SceneManager.LoadScene((int)Scenes.Game);
    }

    public void EndGame()
    {
        SceneManager.LoadScene((int)Scenes.Retry);
    }

    public void MainMenu()
    {
        SceneManager.LoadScene((int)Scenes.MainMenu);
    }

    public void QuitApp()
    {
        Debug.Log("Quit game");
        Application.Quit();
    }
}
