using UnityEngine;

[System.Serializable]
public class Sound
{
    public string nombre;

    public AudioClip clip;


    [Range(0, 1)]
    public float volumen;

    public bool loop;

    [HideInInspector]
    public AudioSource source;

}
