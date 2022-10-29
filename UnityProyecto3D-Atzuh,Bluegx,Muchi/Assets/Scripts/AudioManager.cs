using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    public static AudioManager Instance;

    public Sound[] sonido;


    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }

        foreach (Sound s in sonido)
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;
            s.source.volume = s.volumen;
            s.source.loop = s.loop;
        }
    }


    public void Play(string nombre)
    {
        foreach (Sound s in sonido)
        {
            if (s.nombre == nombre)
            {
                s.source.Play();
                return;
            }
            else
            {
                //Debug.Log("nO hAy cAnCiOn");
            }
        }
    }

    public void Stop(string nombre)
    {
        foreach (Sound s in sonido)
        {
            if (s.nombre == nombre)
            {
                s.source.Stop();
                return;
            }
            else
            {
                Debug.Log("nO hAy cAnCiOn");
            }
        }
    }
}
