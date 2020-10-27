using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MusicManager : MonoBehaviour
{
    public static MusicManager Instance { get; private set; }

    [SerializeField] AudioSource[] musicBox;
    int selectedSong;

    void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void PlaySong()
    {
        selectedSong = Random.Range(0, musicBox.Length);
        musicBox[selectedSong].Play();
    }

    public void StopSong()
    {
        StartCoroutine(FadeOut(musicBox[selectedSong], 0.5f));
        //musicBox[selectedSong].Stop();
    }

    private static IEnumerator FadeOut(AudioSource audioSource, float FadeTime)
    {
        float startVolume = audioSource.volume;
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }
        audioSource.Stop();
        audioSource.volume = startVolume;
    }
}
