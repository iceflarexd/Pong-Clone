using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public bool isFirstTick = true;
    public Text player1Score, player2Score, winningPlayer;
    public static int player1ScoreFinal, player2ScoreFinal;
    public int player1ScoreInt, player2ScoreInt;
    BoxCollider2D ballBc, wallLeftBc, wallRightBc;

    // Start is called before the first frame update
    void Start()
    {
        ballBc = GameObject.FindGameObjectWithTag("Ball").GetComponent<BoxCollider2D>();
        wallLeftBc = GameObject.FindGameObjectWithTag("WallLeft").GetComponent<BoxCollider2D>();
        wallRightBc = GameObject.FindGameObjectWithTag("WallRight").GetComponent<BoxCollider2D>();

        player1Score.text = "0";
        player2Score.text = "0";
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstTick)
        {
            if (CollisionManager.HasPlayer1Scored(ballBc, wallRightBc))
            {
                isFirstTick = false;
                player1ScoreInt++;
                player1Score.text = player1ScoreInt.ToString();
                GameStateManager.PlayerScored();
            }

            if (CollisionManager.HasPlayer2Scored(ballBc, wallLeftBc))
            {
                isFirstTick = false;
                player2ScoreInt++;
                player2Score.text = player2ScoreInt.ToString();
                GameStateManager.PlayerScored();
            }
        }

        if (!ballBc.IsTouching(wallLeftBc) && !ballBc.IsTouching(wallRightBc))
            isFirstTick = true;

        if (player1ScoreInt == 5)
        {
            player1ScoreFinal = player1ScoreInt;
            player2ScoreFinal = player2ScoreInt;
            SceneManager.LoadScene(2);
        }

        if (player2ScoreInt == 5)
        {
            player1ScoreFinal = player1ScoreInt;
            player2ScoreFinal = player2ScoreInt;
            SceneManager.LoadScene(2);
        }
    }

    public static int GetWinningPlayer(int player1Score, int player2Score) 
    { 
        if (player1Score > player2Score) return 1;
        return 2;
    }
}
