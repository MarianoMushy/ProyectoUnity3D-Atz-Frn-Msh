using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectDeathZone : MonoBehaviour
{
    public GameObject cuboPrefab;
    public Vector3 PosisionV;
    //public Vector3 Rot;
    public bool instanciado = false;

    private void Start()
    {
        PosisionV = transform.position;
        //Rot = transform.rota;
    }
    private void Update()
    {
        if(instanciado == true)
        {
            instanciado = false;
            Instantiate(cuboPrefab, PosisionV, cuboPrefab.transform.rotation);
            Destroy(this.gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "DeathZone")
        {
            instanciado = true;
        }
    }
}
