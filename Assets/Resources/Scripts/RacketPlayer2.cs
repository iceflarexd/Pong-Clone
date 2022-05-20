using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    Rigidbody2D racket2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        racket2 = GetComponent<Rigidbody2D>();

        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            racket2.velocity = transform.up * 400f;
        }
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            racket2.velocity = transform.up * -400f;
        }

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
        {
            racket2.velocity = transform.up * 0f;
        }
    }

    private void ResetPos()
    {
        racket2.transform.localPosition = new Vector2(515, -55);
        GameStateManager.PlayerScored += ResetPos;
    }
}
