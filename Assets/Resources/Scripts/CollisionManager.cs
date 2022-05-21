using UnityEngine;

public class CollisionManager : MonoBehaviour
{
    BoxCollider2D ballBc, racket1Bc, racket2Bc, wallLeftBc, wallRightBc, wallTopBc, wallBottomBc;
    Rigidbody2D ballRb;
    public int counter;
    public static bool isFirstTick = true;
    Vector2 vel;

    // Start is called before the first frame update
    void Start()
    {
        ballBc = GameObject.FindGameObjectWithTag("Ball").GetComponent<BoxCollider2D>();
        racket1Bc = GameObject.FindGameObjectWithTag("RacketPlayer1").GetComponent<BoxCollider2D>();
        racket2Bc = GameObject.FindGameObjectWithTag("RacketPlayer2").GetComponent<BoxCollider2D>();
        wallLeftBc = GameObject.FindGameObjectWithTag("WallLeft").GetComponent<BoxCollider2D>();
        wallRightBc = GameObject.FindGameObjectWithTag("WallRight").GetComponent<BoxCollider2D>();
        wallTopBc = GameObject.FindGameObjectWithTag("WallTop").GetComponent<BoxCollider2D>();
        wallBottomBc = GameObject.FindGameObjectWithTag("WallBottom").GetComponent<BoxCollider2D>();

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

                GameObject.FindGameObjectWithTag("Ping").AddComponent<SoundManager>().PlaySound();

                if (vel.x < ballRb.velocity.x) vel.x = ballRb.velocity.x;
                if (vel.x > 760) vel.x = 760;

                vel.y = (ballRb.velocity.y / 2) + (racket1Bc.attachedRigidbody.velocity.y / 2.5f);
                if (vel.y > 400) vel.y = 400;
                if (vel.y < -400) vel.y = -400;

                ballRb.velocity = vel;
            }
            if (ballBc.IsTouching(racket2Bc))
            {
                isFirstTick = false;
                counter++;

                GameObject.FindGameObjectWithTag("Ping").AddComponent<SoundManager>().PlaySound();

                if (vel.x < ballRb.velocity.x) vel.x = ballRb.velocity.x;
                if (vel.x > 800) vel.x = 800;

                vel.y = (ballRb.velocity.y / 2) + (racket1Bc.attachedRigidbody.velocity.y / 2.5f);

                ballRb.velocity = vel;
            }
        }

        if (!ballBc.IsTouching(racket1Bc) && !ballBc.IsTouching(racket2Bc) && counter != 0)
            isFirstTick = true;

        if (ballBc.IsTouching(wallTopBc) || ballBc.IsTouching(wallBottomBc))
        {
            GameObject.FindGameObjectWithTag("Pong").AddComponent<SoundManager>().PlaySound();
        }
    }

    public static bool HasPlayer1Scored(BoxCollider2D ballBc, BoxCollider2D wallRightBc)
    {
        if (ballBc.IsTouching(wallRightBc))
        {
            isFirstTick = true;
            return true;
        }
        return false;
    }
    public static bool HasPlayer2Scored(BoxCollider2D ballBc, BoxCollider2D wallLeftBc)
    {
        if (ballBc.IsTouching(wallLeftBc))
        {
            isFirstTick = true;
            return true;
        }
        return false;
    }
}
