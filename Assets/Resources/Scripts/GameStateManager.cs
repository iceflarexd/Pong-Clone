using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameStateManager : MonoBehaviour
{
    public static bool isPaused = false;
    public Text winningPlayer;

    public delegate void GameState();
    public static GameState PlayerScored;

    // Start is called before the first frame update
    void Start()
        => SetWinningPlayer();

    public void SetWinningPlayer()
        => winningPlayer.text = $"Player {ScoreManager.GetWinningPlayer()} wins!";
}