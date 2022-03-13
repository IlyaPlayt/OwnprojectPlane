using System;
using UnityEngine;
using UnityEngine.UI;

public class MainMenu: MonoBehaviour
{
    [SerializeField] private Button PlayButton;
    [SerializeField] private Button AirplaneMenuButton;
    [SerializeField] private Button RatingButton;
    [SerializeField] private Button ExitButton;
    
    [SerializeField] private GameObject PlayMenu;
    [SerializeField] private GameObject AirplaneMenu;
    [SerializeField] private GameObject RatingMenu;
    [SerializeField] private GameObject ExitMenu;

    private void OnEnable()
    {
        PlayButton.onClick.AddListener(ActivatePlayMenu);
        AirplaneMenuButton.onClick.AddListener(ActivateAirplaneMenu);
        RatingButton.onClick.AddListener(ActivateRatingMenu);
        ExitButton.onClick.AddListener(ActivateExitMenu);
    }

    private void OnDisable()
    {
        PlayButton.onClick.RemoveListener(ActivatePlayMenu);
        AirplaneMenuButton.onClick.RemoveListener(ActivateAirplaneMenu);
        RatingButton.onClick.RemoveListener(ActivateRatingMenu);
        ExitButton.onClick.RemoveListener(ActivateExitMenu);
    }

    private void Start()
    {
        PlayMenu.gameObject.SetActive(false);
        AirplaneMenu.gameObject.SetActive(false);
        RatingMenu.gameObject.SetActive(false);
    }

    private void ActivatePlayMenu()
    {
        PlayMenu.gameObject.SetActive(true);
    }
    private void ActivateAirplaneMenu()
    {
        AirplaneMenu.gameObject.SetActive(true);
    }
    private void ActivateRatingMenu()
    {
        RatingMenu.gameObject.SetActive(true);
    }

    private void ActivateExitMenu()
    {
        ExitMenu.gameObject.SetActive(true);
    }

    public void Deactivate()
    {
        PlayMenu.gameObject.SetActive(false);
        AirplaneMenu.gameObject.SetActive(false);
        RatingMenu.gameObject.SetActive(false);
        gameObject.SetActive(false);
    }

    public void Activate()
    {
        gameObject.SetActive(true);
    }
    
    
}