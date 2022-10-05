using UnityEngine;

[System.Serializable]
public class Dialogue
{
    public string nombre;

    [TextArea(3, 10)]
    public string palabras;
    public Sprite caras;
}
