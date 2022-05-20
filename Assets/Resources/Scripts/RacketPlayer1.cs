using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    Rigidbody2D racket1;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        racket1 = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.W))
        {
            racket1.velocity = transform.up * 300f;
        }
        if (Input.GetKeyDown(KeyCode.S))
        {
            racket1.velocity = transform.up * -300f;
        }

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
        {
            racket1.velocity = transform.up * 0f;
        }
    }

    private void ResetPos()
    {
        racket1.transform.localPosition = new Vector2(-530, -55);
        GameStateManager.PlayerScored += ResetPos;
    }
}
