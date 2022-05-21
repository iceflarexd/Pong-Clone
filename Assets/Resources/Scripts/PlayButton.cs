using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayButton : MonoBehaviour
{
    public void OnPlayClick()
        => SceneManager.LoadScene(1);

    public void OnQuitClick()
        => Application.Quit();

    public void OnMenuClick()
        => SceneManager.LoadScene(0);
}