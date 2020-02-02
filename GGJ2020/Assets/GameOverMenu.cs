using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject firstSelectedButton;
    [SerializeField] private TextMeshProUGUI reasonText;

    public void GameOver(string reason)
    {
        reasonText.text = reason;

        // select first button for keyboard and gamepad navigation
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);

        // Hide all HUD elements in the scene
        foreach (var HUDElement in GameObject.FindGameObjectsWithTag("HUD"))
        {
            HUDElement.SetActive(false);
        }

        // stop time
        Time.timeScale = 0f;

        // show panel
        panel.SetActive(true);
    }

    public void Retry()
    {
        Time.timeScale = 1f;
        
        // reload this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
