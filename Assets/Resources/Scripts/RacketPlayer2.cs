using UnityEngine;

public class RacketPlayer2 : MonoBehaviour
{
    Rigidbody2D racket2;
    private float sensitivity;

    private void Start()
        => sensitivity = RacketSensitivity.sensitivity;

    // Update is called once per frame
    void Update()
    {
        racket2 = GetComponent<Rigidbody2D>();

        if (Input.GetKey(KeyCode.UpArrow))
            racket2.velocity = transform.up * sensitivity;

        if (Input.GetKey(KeyCode.DownArrow))
            racket2.velocity = transform.up * -sensitivity;

        if (Input.GetKeyUp(KeyCode.UpArrow) || Input.GetKeyUp(KeyCode.DownArrow))
            racket2.velocity = transform.up * 0f;
    }

    private void ResetPos()
    {
        racket2.transform.localPosition = new Vector2(515, -55);
        GameStateManager.PlayerScored += ResetPos;
    }

    private void OnDestroy()
        => GameStateManager.PlayerScored -= ResetPos;
}
