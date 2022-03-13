using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ExitMenu : MonoBehaviour
{
    [SerializeField] private Button yesButton;
    [SerializeField] private Button noButton;

    private void OnEnable()
    {
        yesButton.onClick.AddListener(Exit);
        noButton.onClick.AddListener(CloseMenu);
    }

    private void Exit()
    {
        Application.Quit();
    }

    private void CloseMenu()
    {
        gameObject.SetActive(false);
    }
}
