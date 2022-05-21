using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseManager : MonoBehaviour
{
    PauseAction action;
    public static bool paused = false;
    public GameObject pauseMenu, player1Text, player2Text, player1Score, player2Score;

    private void Awake()
    {
        action = new PauseAction();
    }

    private void OnEnable()
    {
        action.Enable();
    }

    private void OnDisable()
    {
        action.Disable();
    }

    private void Start()
    {
        action.Pause.PauseGame.performed += _ => GetPauseState();
        ResumeGame();
    }

    private void Update()
    {
        if (paused) PauseGame();
        else ResumeGame();
    }

    private void GetPauseState()
    {
        if (paused) ResumeGame();
        else PauseGame();
    }

    public void PauseGame()
    {
        paused = true;
        UpdateUI();
        pauseMenu.SetActive(true);
        Time.timeScale = 0;
    }

    public void ResumeGame()
    {
        paused = false;
        UpdateUI();
        pauseMenu.SetActive(false);
        Time.timeScale = 1;
    }

    private void UpdateUI()
    {
        player1Text.SetActive(!paused);
        player2Text.SetActive(!paused);
        player1Score.SetActive(!paused);
        player2Score.SetActive(!paused);
    }
}
