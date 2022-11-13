using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public Vector3 lastCheckpointPos;
    public int tiempoActual;

    public Material skyMat1;
    public Material skyMat2;
    public Material skyMat3;


    void Awake()
    {
        if(instance == null)
        {
            instance = this;
            DontDestroyOnLoad(instance);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    private void Update()
    {
        if(tiempoActual >= 16 && tiempoActual < 20)
        {
            RenderSettings.skybox = skyMat2;
        }
        else if(tiempoActual >= 20 || tiempoActual >= 1 && tiempoActual <= 6)
        {
            RenderSettings.skybox = skyMat3;
        }
    }
}
