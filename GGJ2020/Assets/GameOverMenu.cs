﻿using System.Collections;
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
    private bool gameIsOver = false;

    private bool retryPressed = false;

    public void GameOver(string reason)
    {
        if (gameIsOver) return;

        reasonText.text = reason;

        // select first button for keyboard and gamepad navigation
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);

        // Hide all HUD elements in the scene
        foreach (var HUDElement in GameObject.FindGameObjectsWithTag("HUD"))
        {
            HUDElement.SetActive(false);
        }

        // stop time with a little delay so we can see the stage falling and other game over animations in game
        Invoke(nameof(StopTime), 2);

        // show panel
        panel.SetActive(true);

        gameIsOver = true;
    }

    public void Retry()
    {
        Time.timeScale = 1f;

        // reload this scene
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void StopTime()
    {
        Time.timeScale = 0f;
    }
}
