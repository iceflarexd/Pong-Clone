using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollisionManager : MonoBehaviour
{
    BoxCollider2D ballBc, racket1Bc, racket2Bc, wallLeftBc, wallRightBc;
    Rigidbody2D ballRb;
    public int counter;
    public bool isFirstTick = true;
    Vector2 vel;


    // Start is called before the first frame update
    void Start()
    {
        ballBc = GameObject.FindGameObjectWithTag("Ball").GetComponent<BoxCollider2D>();
        racket1Bc = GameObject.FindGameObjectWithTag("RacketPlayer1").GetComponent<BoxCollider2D>();
        racket2Bc = GameObject.FindGameObjectWithTag("RacketPlayer2").GetComponent<BoxCollider2D>();
        wallLeftBc = GameObject.FindGameObjectWithTag("WallLeft").GetComponent<BoxCollider2D>();
        wallRightBc = GameObject.FindGameObjectWithTag("WallRight").GetComponent<BoxCollider2D>();

        ballRb = GameObject.FindGameObjectWithTag("Ball").GetComponent<Rigidbody2D>();

        vel.x = 250;
    }

    // Update is called once per frame
    void Update()
    {
        if (isFirstTick)
        {
            if (ballBc.IsTouching(racket1Bc))
            {
                isFirstTick = false;
                counter++;
                if (vel.x < ballRb.velocity.x) vel.x = ballRb.velocity.x;
                vel.y = (ballRb.velocity.y / 2) + (racket1Bc.attachedRigidbody.velocity.y / 2.5f);
                if (vel.x > 760) vel.x = 760;
                ballRb.velocity = vel;
            }
            if (ballBc.IsTouching(racket2Bc))
            {
                isFirstTick = false;
                counter++;
                if (vel.x < ballRb.velocity.x) vel.x = ballRb.velocity.x;
                vel.y = (ballRb.velocity.y / 2) + (racket1Bc.attachedRigidbody.velocity.y / 2.5f);
                if (vel.x > 800) vel.x = 800;
                ballRb.velocity = vel;
            }
        }

        if (!ballBc.IsTouching(racket1Bc) && !ballBc.IsTouching(racket2Bc) && counter != 0)
            isFirstTick = true;
    }

    public static bool HasPlayer1Scored(BoxCollider2D ballBc, BoxCollider2D wallRightBc)
    {
        if (ballBc.IsTouching(wallRightBc)) return true;
        return false;
    }
    public static bool HasPlayer2Scored(BoxCollider2D ballBc, BoxCollider2D wallLeftBc)
    {
        if (ballBc.IsTouching(wallLeftBc)) return true;
        return false;
    }

}
