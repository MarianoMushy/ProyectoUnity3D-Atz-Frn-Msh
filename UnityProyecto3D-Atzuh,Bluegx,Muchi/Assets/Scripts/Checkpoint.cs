using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Checkpoint : MonoBehaviour
{
    private GameManager gm;
    public int checkPointNum;

   

    private void Start()
    {
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            gm.lastCheckpointPos = transform.position;
            
        }

        if(checkPointNum == 1)
        {
            GameManager.instance.tiempoActual = 9;
            RenderSettings.ambientIntensity = 2f;
        }

        if (checkPointNum == 2)
        {
            GameManager.instance.tiempoActual = 11;
            RenderSettings.ambientIntensity = 1.5f;
        }

        if (checkPointNum == 3)
        {
            GameManager.instance.tiempoActual = 13;
            RenderSettings.ambientIntensity = 1.2f;
        }

        if (checkPointNum == 4)
        {
            GameManager.instance.tiempoActual = 15;
            RenderSettings.ambientIntensity = .9f;
        }

        if (checkPointNum == 5)
        {
            GameManager.instance.tiempoActual = 17;
            RenderSettings.ambientIntensity = .6f;
        }


        if (checkPointNum == 6)
        {
            GameManager.instance.tiempoActual = 20;
            RenderSettings.ambientIntensity = .3f;
        }

    }
}
