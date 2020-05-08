using System;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.UI;


public class PauseMenu : MonoBehaviour
{
    [SerializeField] private Button ResumeButton;
    [SerializeField] private Button RestartButton;
    [SerializeField] private Button LoadLevelButton;
    [SerializeField] private Button SettingsButoon;
    [SerializeField] private Button MainMenuButoon;
    [SerializeField] private Button RageQuitButton;

    private void Start()
    {
        ResumeButton.onClick.AddListener(HandleResume);
        RestartButton.onClick.AddListener(HandleRestart);
        LoadLevelButton.onClick.AddListener(HadleLoading);
        MainMenuButoon.onClick.AddListener(MainMenuButton);
        RageQuitButton.onClick.AddListener(HandleRageQuit);
    }


    private void HandleResume()
    {
        GameManager.Instance.TogglePause();
    }

    private void HandleRestart()
    {
        GameManager.Instance.RestartGame();
    }

    private void HadleLoading()
    {
        LoadLevelButton.onClick.AddListener(UIManager.Instance.HandleLevelSelect);
    }


    private void MainMenuButton()
    {
        GameManager.Instance.BackToMenu();
    }

    private void HandleRageQuit()
    {
        Application.Quit();
    }
}
