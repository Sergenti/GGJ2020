using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public void StartGame()
    {
        SceneManager.LoadScene("DifficultyScene");
    }

    public void ExitGame()
    {
        Application.Quit();
    }
    
    public void OpenOptions()
    {
        Debug.Log("There are no options yet...");
    }
}
