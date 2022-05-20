using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallMovement : MonoBehaviour
{
    Rigidbody2D ball;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        float posY = Random.Range(-150, 150);
        ball = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();
        transform.localPosition = new Vector2(-19, posY);
        vel.x = 250;
        vel.y = -150;
        ball.velocity = vel;
        GameStateManager.PlayerScored += Start;
    }

    // Update is called once per frame
    void Update()
    {

    }
}
