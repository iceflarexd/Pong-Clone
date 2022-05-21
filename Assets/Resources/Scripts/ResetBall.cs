using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetBall : MonoBehaviour
{
    public void ResetBallClick()
    {
        GameStateManager.PlayerScored();
        PauseManager.paused = false;
    }
}
