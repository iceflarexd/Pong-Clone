using UnityEngine;

public class SoundManager : MonoBehaviour
{
    private AudioSource sound;

    private void Awake()
    {
        if (transform.gameObject == GameObject.FindGameObjectWithTag("Bgm"))
        {
            DontDestroyOnLoad(transform.gameObject);
        }
        sound = GetComponent<AudioSource>();

        GameObject.FindGameObjectWithTag("Bgm").GetComponent<SoundManager>().PlaySound();
    }

    public void PlaySound()
    {
        if (sound.isPlaying) return;
        sound.Play();
    }

    public void StopSound()
        => sound.Stop();
}
