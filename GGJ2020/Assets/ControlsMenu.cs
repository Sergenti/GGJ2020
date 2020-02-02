using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.EventSystems;

public class ControlsMenu : MonoBehaviour
{
    [SerializeField] private GameObject firstSelectedButton;

    void Awake()
    {
        EventSystem.current.SetSelectedGameObject(firstSelectedButton);
    }
    public void Back()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
