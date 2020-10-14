using UnityEngine.Audio;
using System;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public AudioMixerGroup audioMixer;

    public static AudioManager Instance { get; private set; }
    public Sound[] soundList;
    

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

        //DontDestroyOnLoad(this.gameObject);

        foreach (Sound s in soundList)
        {
            //vol = s.Fuente.volume + 1f;
            s.Source = gameObject.AddComponent<AudioSource>();
            s.Source.outputAudioMixerGroup = audioMixer;
            s.Source.clip = s.pista;
            s.Source.volume = s.Vol;
            s.Source.pitch = s.Pitch;
            s.Source.loop = s.Loop;
        }
    }
    
    public void Play(string Nombre)
    {
        Sound s = Array.Find(soundList, Sonido => Sonido.Nombre == Nombre);
        if(s == null)
        {
            Debug.LogWarning("Sonido:" + Nombre + "no encontrado");
            return;
        }
        s.Source.PlayOneShot(s.Source.clip, s.Source.volume);
    }

    public void Stop(string Nombre)
    {
        Sound s = Array.Find(soundList, Sonido => Sonido.Nombre == Nombre);
        if (s == null)
        {           
            return;
        }
        s.Source.Stop();
    }
}
