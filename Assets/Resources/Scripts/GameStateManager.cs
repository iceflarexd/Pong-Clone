using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        SetWinningPlayer();
    }

    public delegate void GameState();

    public static GameState PlayerScored, PlayerWon;

    public Text winningPlayer;

    public void SetWinningPlayer()
    {
        winningPlayer.text = $"Player {ScoreManager.GetWinningPlayer(ScoreManager.player1ScoreFinal, ScoreManager.player2ScoreFinal)} wins!";
    }
}
