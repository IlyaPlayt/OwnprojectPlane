using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;
using UnityEngine.UI;

public class UiController : MonoBehaviour
{
    [SerializeField] private EventeController _eventeController;
    
    [SerializeField] private Text timeText;
    [SerializeField] private ScoreController _scoreController;

    [SerializeField] private LosePopup losePopup;
    [SerializeField] private WinPopup winPopup;
    [SerializeField] private MainMenu mainMenu;

    private void OnEnable()
    {
        _eventeController.PlayerLoose += PlayerLose;
        _eventeController.PlayerWin += PlayerWin;
        _eventeController.GameStart += GameStart;
        winPopup.restartButton.onClick.AddListener(Restart);
        losePopup.restartButton.onClick.AddListener(Restart);
        winPopup.exitButton.onClick.AddListener(ExitToMainMenu);
        losePopup.exitButton.onClick.AddListener(ExitToMainMenu);
        
    }

    private void OnDisable()
    {
        _eventeController.PlayerLoose -= PlayerLose;
        _eventeController.PlayerWin -= PlayerWin;
        _eventeController.GameStart -= GameStart;
        winPopup.restartButton.onClick.RemoveListener(Restart);
        losePopup.restartButton.onClick.RemoveListener(Restart);
        winPopup.exitButton.onClick.RemoveListener(ExitToMainMenu);
        losePopup.exitButton.onClick.RemoveListener(ExitToMainMenu);
    }

    void Start()
    {
        losePopup.Hide();
        winPopup.Hide();
    }


    void Update()
    {
        timeText.text = Mathf.Round(_scoreController.currentTime).ToString();
    }

    void GameStart()
    {
        losePopup.Hide();
        winPopup.Hide();
        mainMenu.Deactivate();
        timeText.gameObject.SetActive(true);
    }

    private void PlayerWin()
    {
        winPopup.Activate((int) Mathf.Round(_scoreController.currentTime));
        timeText.gameObject.SetActive(false);
    }

    private void PlayerLose(string reason)
    {
        losePopup.Activate(reason);
    }

    private void Restart()
    {
        losePopup.Hide();
        winPopup.Hide();
        timeText.gameObject.SetActive(true);
        _eventeController.RestartInvoke();
    }

    private void ExitToMainMenu()
    {
        losePopup.Hide();
        winPopup.Hide();
        mainMenu.Activate();
        _eventeController.ExitToMainMenuInvoke();
    }
}