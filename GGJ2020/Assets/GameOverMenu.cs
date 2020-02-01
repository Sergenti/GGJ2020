using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using TMPro;

public class GameOverMenu : MonoBehaviour
{
    [SerializeField] private GameObject panel;
    [SerializeField] private GameObject firstSelectedButton;
    [SerializeField] private TextMeshProUGUI reasonText;

    public void GameOver(string reason)
    {
        reasonText.text = reason;

        if (!EventSystem.current.alreadySelecting)
        {
            EventSystem.current.SetSelectedGameObject(firstSelectedButton);
        }

        panel.SetActive(true);
    }
}
