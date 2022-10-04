using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpringPlayer : MonoBehaviour
{
    ThirdPersonController moveScript;

    public float pushSpeed;
    public float pushTime;
    public bool spring = false;


    private void Start()
    {
        moveScript = GetComponent<ThirdPersonController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spring")
        {
            spring = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Spring")
        {
            spring = false;
        }
    }

    private void Update()
    {
        if (spring == true)
        {
            StartCoroutine(Push());

        }
    }

    IEnumerator Push()
    {
        float startTime = Time.time;

        while (Time.time < startTime + pushTime)
        {
            //moveScript.controller.Move(moveScript.moveDir * -pushSpeed * Time.deltaTime);
            moveScript.Jump(pushSpeed);

            yield return null;
        }
    }
}
