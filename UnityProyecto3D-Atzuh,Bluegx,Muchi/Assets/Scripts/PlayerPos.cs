using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPos : MonoBehaviour
{
    private GameManager gm;
    public CharacterController controller;

    private void Start()
    {
        controller.enabled = false;
        gm = GameObject.FindGameObjectWithTag("GameManager").GetComponent<GameManager>();
        transform.position = gm.lastCheckpointPos;
        controller.enabled = true;
    }

    
}
