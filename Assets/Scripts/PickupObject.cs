﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupObject : MonoBehaviour
{

    public GameObject ObjectToPickUp;
    public GameObject PickedObject; 
    public Transform interactionZone;

    void Update()
    {
        if(ObjectToPickUp !=null && ObjectToPickUp.GetComponent<PickableObject>().isPickable==true && PickedObject == null)
        {
            if(Input.GetButtonDown("Jump"))//(Input.GetKeyDown(KeyCode.F))
            {
                PickedObject = ObjectToPickUp;
                PickedObject.GetComponent<PickableObject>().isPickable=false;
                PickedObject.transform.SetParent(interactionZone);
                Vector3 pos = interactionZone.position;
                pos.y += 1f;
                PickedObject.transform.position = pos;

                PickedObject.GetComponent<Rigidbody>().useGravity = false;
                PickedObject.GetComponent<Rigidbody>().isKinematic = true;
                if(PickedObject.GetComponent<CableEnd>() != null)
                {
                    PickedObject.GetComponent<CableEnd>().estaConectado = false;
                }
            }   
        }else if(PickedObject!=null)
        {
            if(Input.GetButtonDown("Jump")) //(Input.GetKeyDown(KeyCode.F))
            {

                PickedObject.GetComponent<PickableObject>().isPickable=true;
                PickedObject.transform.SetParent(null);
                
                PickedObject.GetComponent<Rigidbody>().useGravity = true;
                PickedObject.GetComponent<Rigidbody>().isKinematic = false;
                
                PickedObject= null;
            }

        } 


    }
}

