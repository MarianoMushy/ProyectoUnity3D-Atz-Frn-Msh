using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PickUpObjects : MonoBehaviour
{
    public GameObject objectToPickup;
    public GameObject pickedObject;
    public Transform interactionZone;

    private void Update()
    {
        if(objectToPickup != null && objectToPickup.GetComponent<PickableObject>().isPickable == true && pickedObject == null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                pickedObject = objectToPickup;
                pickedObject.GetComponent<PickableObject>().isPickable = false;
                pickedObject.transform.SetParent(interactionZone);
                pickedObject.transform.position = interactionZone.position;
                pickedObject.GetComponent<Rigidbody>().useGravity = false;
                pickedObject.GetComponent<Rigidbody>().isKinematic = true;
                
                if(pickedObject.tag == "Cube")
                {
                    pickedObject.GetComponentInChildren<BoxCollider>().isTrigger = true;
                }
                else if(pickedObject.tag == "Sphere")
                {
                    pickedObject.GetComponentInChildren<SphereCollider>().isTrigger = true;
                }

                
               
            }
        }
        else if(pickedObject != null)
        {
            if (Input.GetKeyDown(KeyCode.F))
            {
                
                pickedObject.GetComponent<PickableObject>().isPickable = true;
                pickedObject.transform.SetParent(null);
                
                pickedObject.GetComponent<Rigidbody>().useGravity = true;
                pickedObject.GetComponent<Rigidbody>().isKinematic = false;

                if (pickedObject.tag == "Cube")
                {
                    pickedObject.GetComponentInChildren<BoxCollider>().isTrigger = false;
                }
                else if (pickedObject.tag == "Sphere")
                {
                    pickedObject.GetComponentInChildren<SphereCollider>().isTrigger = false;
                }

                pickedObject = null;
            }
        }
    }
}
