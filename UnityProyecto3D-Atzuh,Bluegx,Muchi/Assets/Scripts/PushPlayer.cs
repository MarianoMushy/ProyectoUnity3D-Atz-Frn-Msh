using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PushPlayer : MonoBehaviour
{
    ThirdPersonController moveScript;

    public float pushSpeed;
    public float pushTime;
    public bool sumo = false;


    private void Start()
    {
        moveScript = GetComponent<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Sumo")
        {
            sumo = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Sumo")
        {
            sumo = false;
        }
    }

    private void Update()
    {
        if (sumo == true)
        {
            StartCoroutine(Push());
            
        }
    }

    IEnumerator Push()
    {
        float startTime = Time.time;

        while(Time.time < startTime + pushTime)
        {
            moveScript.controller.Move(moveScript.moveDir * -pushSpeed * Time.deltaTime);

            yield return null;
        }
    }
}
