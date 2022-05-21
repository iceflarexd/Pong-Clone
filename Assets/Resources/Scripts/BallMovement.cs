using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D ball;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        GameStateManager.PlayerScored += OnPlayerScored;
        OnPlayerScored();
    }

    private void OnPlayerScored()
    {
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();

        float posY = Random.Range(-150, 150);
        transform.localPosition = new Vector2(-19, posY);
        vel.y = posY * 1.5f;

        int startingSide = Random.Range(1, 3);
        if (startingSide == 1) vel.x = -250;
        else vel.x = 250;

        ball.velocity = vel;
    }

    private void OnDestroy()
        => GameStateManager.PlayerScored -= OnPlayerScored;
}
