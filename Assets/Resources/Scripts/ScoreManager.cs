using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour
{
    public bool isFirstTick = true;
    public Text player1Score, player2Score, winningPlayer;
    public static int player1ScoreInt, player2ScoreInt;
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
                GameObject.FindGameObjectWithTag("Goal").GetComponent<SoundManager>().PlaySound();
                isFirstTick = false;
                player1ScoreInt++;
                player1Score.text = player1ScoreInt.ToString();
                GameStateManager.PlayerScored();
            }

            if (CollisionManager.HasPlayer2Scored(ballBc, wallLeftBc))
            {
                GameObject.FindGameObjectWithTag("Goal").GetComponent<SoundManager>().PlaySound();
                isFirstTick = false;
                player2ScoreInt++;
                player2Score.text = player2ScoreInt.ToString();
                GameStateManager.PlayerScored();
            }
        }

        if (!ballBc.IsTouching(wallLeftBc) && !ballBc.IsTouching(wallRightBc))
            isFirstTick = true;

        if (player1ScoreInt == 5 || player2ScoreInt == 5)
            SceneManager.LoadScene(2);
    }

    public static int GetWinningPlayer() 
    { 
        if (player1ScoreInt > player2ScoreInt) return 1;
        return 2;
    }
}
