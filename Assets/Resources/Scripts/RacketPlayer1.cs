using UnityEngine;

public class RacketPlayer1 : MonoBehaviour
{
    Rigidbody2D racket1;
    private float sensitivity;

    private void Start()
        => sensitivity = RacketSensitivity.sensitivity;


    // Update is called once per frame
    void Update()
    {
        racket1 = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.W))
            racket1.velocity = transform.up * sensitivity;

        if (Input.GetKey(KeyCode.S))
            racket1.velocity = transform.up * -sensitivity;

        if (Input.GetKeyUp(KeyCode.W) || Input.GetKeyUp(KeyCode.S))
            racket1.velocity = transform.up * 0f;
    }

    private void ResetPos()
    {
        racket1.transform.localPosition = new Vector2(-530, -55);
        GameStateManager.PlayerScored += ResetPos;
    }

    private void OnDestroy()
        => GameStateManager.PlayerScored -= ResetPos;
}
