using UnityEngine.Audio;
using UnityEngine;


[System.Serializable]
public class Sound
{
    public string Nombre;

    public AudioClip pista;

    [Range(0f, 1f)]
    public float Vol;
    [Range(.1f, 3f)]
    public float Pitch;

    public bool Loop;

    [HideInInspector]
    public AudioSource Source;
}
